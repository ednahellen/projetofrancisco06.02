using GPSFA_WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace SistemaArrecadacaoAlimentos
{
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            using (var conexao = DataBaseConnection.OpenConnection())
             {
                 if (conexao == null)
                 {
                     MessageBox.Show("Não foi possível conectar ao banco de dados.", 
                         "Erro", MessageBoxButtons.OK, 
                         MessageBoxIcon.Error);
                     return;
                 }
            }
            
            CarregarListaProdutos();
            CarregarGraficoProdutos();
            CarregarGraficoMensal();
            AtualizarTotais();
            AtualizarLabelMesAtual();
        }

        private void CarregarListaProdutos()
        {
            dgvProdutos.Rows.Clear();

            string query = @"SELECT nome, quantidade, dataArrecadacao, unidade
                           FROM tbProdutos
                           ORDER BY dataArrecadacao DESC
                           LIMIT 10";

            try
            {
                using (var conexao = DataBaseConnection.OpenConnection())
                {
                    conexao.Open();
                    using (var cmd = new MySqlCommand(query, conexao))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvProdutos.Rows.Add(
                                    reader["nome"],
                                    reader["quantidade"],
                                    reader["unidade"],
                                    reader["dataArrecadacao"]
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGraficoProdutos()
        {
            chartProdutos.Series.Clear();
            chartProdutos.Titles.Clear();

            var series = new Series("Produtos Recebidos")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            string query = @"SELECT nome, SUM(quantidade) AS totalQuantidade
                           FROM tbProdutos
                           GROUP BY nome
                           ORDER BY totalQuantidade DESC
                           LIMIT 8";

            try
            {
                using (var conexao = DataBaseConnection.OpenConnection())
                {
                    conexao.Open();
                    using (var cmd = new MySqlCommand(query, conexao))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string nome = reader["nome"].ToString();
                                if (nome.Length > 15) nome = nome.Substring(0, 12) + "...";

                                series.Points.AddXY(
                                    nome,
                                    Convert.ToDouble(reader["totalQuantidade"])
                                );
                            }
                        }
                    }
                }

                chartProdutos.Series.Add(series);
                chartProdutos.Titles.Add("Produtos Mais Recebidos (Quantidade)");
                chartProdutos.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar gráfico de produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGraficoMensal()
        {
            chartMensal.Series.Clear();
            chartMensal.Titles.Clear();

            var series = new Series("Itens por Mês")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true
            };

            string query = @"SELECT 
                YEAR(dataArrecadacao) AS ano, 
                MONTH(dataArrecadacao) AS mes, 
                SUM(quantidade) AS totalMensal
                FROM tbProdutos 
                GROUP BY YEAR(dataArrecadacao), MONTH(dataArrecadacao)
                ORDER BY ano, mes";

            try
            {
                using (var conexao = DataBaseConnection.OpenConnection())
                {
                    conexao.Open();
                    using (var cmd = new MySqlCommand(query, conexao))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int mes = Convert.ToInt32(reader["mes"]);
                                int ano = Convert.ToInt32(reader["ano"]);
                                string label = $"{mes}/{ano}";

                                series.Points.AddXY(
                                    label,
                                    Convert.ToDouble(reader["totalMensal"])
                                );
                            }
                        }
                    }
                }

                chartMensal.Series.Add(series);
                chartMensal.Titles.Add("Quantidade de Itens por Mês");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar gráfico mensal: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTotais()
        {
            string queryTotalItens = "SELECT SUM(quantidade) as total_itens FROM tbProdutos";
            string queryTotalKilos = @"SELECT SUM(quantidade * peso) as total_peso 
                                     FROM tbProdutos 
                                     WHERE unidade = 'KG'";

            try
            {
                using (var conexao = DataBaseConnection.OpenConnection())
                {
                    conexao.Open();

                    // Total de itens
                    using (var cmd = new MySqlCommand(queryTotalItens, conexao))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalItens.Text = result != DBNull.Value ? Convert.ToInt64(result).ToString("N0") : "0";
                    }

                    // Total em quilos
                    using (var cmd = new MySqlCommand(queryTotalKilos, conexao))
                    {
                        object result = cmd.ExecuteScalar();
                        lblTotalKilos.Text = result != DBNull.Value ? Convert.ToDecimal(result).ToString("N2") + " kg" : "0 kg";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar totais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
            MessageBox.Show("Dados atualizados com sucesso!", "Atualização",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void btnCadastroProdutos_Click(object sender, EventArgs e)
        //{
        //    var frmCadastro = new frmCadastroProdutos();
        //    frmCadastro.ShowDialog();
        //    CarregarDados();
        //}

        //private void btnEstoque_Click(object sender, EventArgs e)
        //{
        //    var frmEstoque = new frmEstoque();
        //    frmEstoque.ShowDialog();
        //}

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AtualizarLabelMesAtual()
        {
            try
            {
                string query = @"SELECT COUNT(*) as total_mes_atual 
                       FROM tbProdutos 
                       WHERE MONTH(dataArrecadacao) = MONTH(CURDATE()) 
                       AND YEAR(dataArrecadacao) = YEAR(CURDATE())";

                using (var conexao = DataBaseConnection.OpenConnection()) 
                {
                    conexao.Open();
                    using(var cmd = new MySqlCommand(query, conexao))
                    {
                        int totalMesAtual = Convert.ToInt32(cmd.ExecuteScalar());
                        if (totalMesAtual > 0)
                        {
                            string[] meses =
                            {
                                "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
                            };
                            string mesAtual = meses[DateTime.Now.Month - 1];
                            int anoAtual = DateTime.Now.Year;

                            lbMesAtual.Text = "Não há arrecadações registradas no mês atual";

                            lbMesAtual.Visible = true;
                            lbMesAtual.ForeColor = Color.Orange;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                lbMesAtual.Text = "Erro ao carregar informações do mês";
                lbMesAtual.Visible = true;
                lbMesAtual.ForeColor = Color.Red;
                Console.WriteLine("Erro ao atualizar label do mês: " + ex.Message);
            }
        }
    }
}
