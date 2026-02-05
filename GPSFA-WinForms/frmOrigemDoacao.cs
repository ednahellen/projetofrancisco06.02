using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPSFA_WinForms
{
    public partial class frmOrigemDoacao : Form
    {
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmOrigemDoacao()
        {
            InitializeComponent();
            desativarBotoes();
            desativarCampos();
        }
        public frmOrigemDoacao(string nome)
        {
            InitializeComponent();
            buscaCodigoOrigem(nome);
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
            txtNomeFornecedor.Text = nome;
        }

        private int excluirOrigem(int codOri)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "DELETE FROM tborigemdoacao WHERE codOri = " + codOri;
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Connection = DataBaseConnection.OpenConnection();

            int resp = comm.ExecuteNonQuery();

            DataBaseConnection.CloseConnection();

            return resp;
        }

        int codOri = 0;


        int respAlterar = 0;
        private int alterarOrigemDoacao(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "UPDATE tborigemdoacao SET nome = @nome WHERE codOri = " + codOri;
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;


            comm.Connection = DataBaseConnection.OpenConnection();

            try
            {
                respAlterar = comm.ExecuteNonQuery();
                DataBaseConnection.CloseConnection();
            }

            catch (Exception)
            {
                MessageBox.Show("Este registro já existe!", "Mensagem do sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                txtNomeFornecedor.Enabled = false;
            }

            return respAlterar;

        }

        public void buscaCodigoOrigem(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = $"SELECT codOri FROM tborigemdoacao WHERE nome LIKE '%{nome}%';";

            comm.CommandType = CommandType.Text;

            comm.Connection = DataBaseConnection.OpenConnection();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            codOri = 0;

            while (DR.Read())
            {
                codOri = DR.GetInt32(0);
            }

            DataBaseConnection.CloseConnection();
        }

        public void desativarBotoes()
        {
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = false;
            btnLimpar.Enabled = false;           
        }

        public void desativarCampos()
        {
            txtNomeFornecedor.Enabled = false;
            txtRua.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            txtReferencia.Enabled = false;
            mskCep.Enabled = false;
            mskTelefone.Enabled = false;
            mskCpf.Enabled = false;
            mskCnpj.Enabled = false;
            cbbEstado.Enabled = false;
            cbbCidade.Enabled = false;
            rdbCpf.Enabled = false;
            rdbCnpj.Enabled = false;
        }

        public void habilitaCampos()
        {
            txtNomeFornecedor.Enabled = true;
            txtRua.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            txtBairro.Enabled = true;
            txtReferencia.Enabled = true;
            mskCep.Enabled = true;
            mskTelefone.Enabled = true;
            mskCpf.Enabled = false;
            mskCnpj.Enabled = false;
            cbbEstado.Enabled = true;
            cbbCidade.Enabled = true;
            rdbCpf.Enabled = true;
            rdbCnpj.Enabled = true;
        }

        public void limparCampos()
        {

        }

        public int cadastrarFornecedores(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "INSERT INTO tborigemdoacao(nome)VALUES(@nome);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = DataBaseConnection.OpenConnection();

            try
            {
                int resp = comm.ExecuteNonQuery();

                DataBaseConnection.CloseConnection();

                return resp;
            }
            catch (Exception)
            {
                MessageBox.Show("Este registro já existe!", "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            return 0;
        }

        //private int buscaOrigemDoacao(string nome)
        //{
        //    MySqlCommand comm = new MySqlCommand();
        //    comm.CommandText = $"SELECT nome FROM tborigemdoacao WHERE nome LIKE '%{nome}%';";
        //    comm.CommandType = CommandType.Text;

        //    comm.Parameters.Clear();

        //    comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;


        //    comm.Connection = DataBaseConnection.OpenConnection();

        //    int resp = comm.ExecuteNonQuery();

        //    DataBaseConnection.CloseConnection();

        //    return resp;
        //}

        private void frmOrigemDoacao_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
           
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerenciarProdutos abrir = new frmGerenciarProdutos();
            abrir.Show();
            this.Hide();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitaCampos();
            txtNomeFornecedor.Focus();
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private void rdbCpf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCpf.Checked.Equals(true))
            {
                mskCpf.Enabled = true;
                mskCpf.Focus();
            }
            else
            {
                mskCpf.Enabled = false;
                mskCpf.Clear();
            }
        }

        private void rdbCnpj_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCnpj.Checked.Equals(true))
            {
                mskCnpj.Enabled = true;
                mskCnpj.Focus();
            }
            else
            {
                mskCnpj.Enabled = false;
                mskCnpj.Clear();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNomeFornecedor.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir um nome!", "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                txtNomeFornecedor.Focus();
            }
            //else if (buscaOrigemDoacao(txtNomeFornecedor.Text).Equals(1))
            //{
            //    MessageBox.Show("Este registro já existe!", "Mensagem do sistema",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information,
            //        MessageBoxDefaultButton.Button1);
            //    txtNomeFornecedor.Focus();
            //}
            else
            {
                //Regex utilizado para remover espaços extras entre as palavras.

                int resp = cadastrarFornecedores(Regex.Replace(txtNomeFornecedor.Text, @"\s+", " ").Trim().ToUpper());

                if (resp.Equals(1))
                {
                    MessageBox.Show("Cadastrado com sucesso!", "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                    desativarBotoes();
                    txtNomeFornecedor.Clear();                    
                    btnNovo.Enabled = true;
                    btnNovo.Focus();
                }
                else
                {
                    MessageBox.Show("Erro ao Cadastrar!", "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);

                    //limparCampos();
                    btnCadastrar.Enabled = false;
                    btnLimpar.Enabled = false;
                    btnNovo.Enabled = true;
                    desativarCampos();

                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarOrigemDoacao abrir = new frmPesquisarOrigemDoacao();
            abrir.Show();
            this.Hide();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir?", "Mensagem do Sistema",
                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result.Equals(DialogResult.Yes))
            {
                int resp = excluirOrigem(codOri);

                if (resp.Equals(1))
                {
                    MessageBox.Show("Excluido com Sucesso!", "Mensagem do Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtNomeFornecedor.Clear();
                    txtNomeFornecedor.Focus();
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnLimpar.Enabled = false;
                    btnNovo.Enabled = true;
                    txtNomeFornecedor.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Erro ao excluir!", "Mensagem do Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtNomeFornecedor.Clear();
                    txtNomeFornecedor.Focus();
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnLimpar.Enabled = false;
                    btnNovo.Enabled = true;
                    txtNomeFornecedor.Enabled = false;
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNomeFornecedor.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores!", "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                txtNomeFornecedor.Enabled = false;
                desativarBotoes();
                btnPesquisar.Focus();
            }
            else if (alterarOrigemDoacao(Regex.Replace(txtNomeFornecedor.Text, @"\s+", " ").Trim().ToUpper()).Equals(1))
            {

                MessageBox.Show("Fornecedor alterado com sucesso!", "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                limparCampos();
                btnLimpar.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnNovo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Erro ao alterar!", "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
                btnLimpar.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnNovo.Enabled = false;
            }
        }
    }

}
