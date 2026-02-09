namespace SistemaArrecadacaoAlimentos
{
    partial class frmRelatorio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalKilos = new System.Windows.Forms.Label();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.lbTotalKg = new System.Windows.Forms.Label();
            this.lbTotalItens = new System.Windows.Forms.Label();
            this.chartProdutos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMensal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnCadastroProdutos = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lbMesAtual = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMensal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.lbMesAtual);
            this.panel1.Controls.Add(this.lblTotalKilos);
            this.panel1.Controls.Add(this.lblTotalItens);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.lbTotalKg);
            this.panel1.Controls.Add(this.lbTotalItens);
            this.panel1.Location = new System.Drawing.Point(16, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1501, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalKilos
            // 
            this.lblTotalKilos.AutoSize = true;
            this.lblTotalKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalKilos.ForeColor = System.Drawing.Color.White;
            this.lblTotalKilos.Location = new System.Drawing.Point(240, 49);
            this.lblTotalKilos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalKilos.Name = "lblTotalKilos";
            this.lblTotalKilos.Size = new System.Drawing.Size(62, 29);
            this.lblTotalKilos.TabIndex = 3;
            this.lblTotalKilos.Text = "0 kg";
            // 
            // lblTotalItens
            // 
            this.lblTotalItens.AutoSize = true;
            this.lblTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItens.ForeColor = System.Drawing.Color.White;
            this.lblTotalItens.Location = new System.Drawing.Point(240, 12);
            this.lblTotalItens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalItens.Name = "lblTotalItens";
            this.lblTotalItens.Size = new System.Drawing.Size(27, 29);
            this.lblTotalItens.TabIndex = 2;
            this.lblTotalItens.Text = "0";
            // 
            // lbTotalKg
            // 
            this.lbTotalKg.AutoSize = true;
            this.lbTotalKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalKg.ForeColor = System.Drawing.Color.White;
            this.lbTotalKg.Location = new System.Drawing.Point(20, 53);
            this.lbTotalKg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalKg.Name = "lbTotalKg";
            this.lbTotalKg.Size = new System.Drawing.Size(155, 25);
            this.lbTotalKg.TabIndex = 1;
            this.lbTotalKg.Text = "Total em Quilos:";
            // 
            // lbTotalItens
            // 
            this.lbTotalItens.AutoSize = true;
            this.lbTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalItens.ForeColor = System.Drawing.Color.White;
            this.lbTotalItens.Location = new System.Drawing.Point(20, 16);
            this.lbTotalItens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalItens.Name = "lbTotalItens";
            this.lbTotalItens.Size = new System.Drawing.Size(136, 25);
            this.lbTotalItens.TabIndex = 0;
            this.lbTotalItens.Text = "Total de Itens:";
            // 
            // chartProdutos
            // 
            this.chartProdutos.BackColor = System.Drawing.Color.Lavender;
            this.chartProdutos.BorderlineColor = System.Drawing.Color.Teal;
            this.chartProdutos.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chartProdutos.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartProdutos.Legends.Add(legend3);
            this.chartProdutos.Location = new System.Drawing.Point(76, 135);
            this.chartProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.chartProdutos.Name = "chartProdutos";
            this.chartProdutos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartProdutos.Series.Add(series3);
            this.chartProdutos.Size = new System.Drawing.Size(667, 369);
            this.chartProdutos.TabIndex = 1;
            this.chartProdutos.Text = "Produtos";
            // 
            // chartMensal
            // 
            this.chartMensal.BackColor = System.Drawing.Color.Lavender;
            this.chartMensal.BorderlineColor = System.Drawing.Color.Teal;
            this.chartMensal.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            this.chartMensal.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartMensal.Legends.Add(legend4);
            this.chartMensal.Location = new System.Drawing.Point(838, 135);
            this.chartMensal.Margin = new System.Windows.Forms.Padding(4);
            this.chartMensal.Name = "chartMensal";
            this.chartMensal.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartMensal.Series.Add(series4);
            this.chartMensal.Size = new System.Drawing.Size(667, 369);
            this.chartMensal.TabIndex = 2;
            this.chartMensal.Text = "chart2";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvProdutos.Location = new System.Drawing.Point(76, 512);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersWidth = 51;
            this.dgvProdutos.Size = new System.Drawing.Size(988, 206);
            this.dgvProdutos.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nome do Produto";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantidade";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Unidade";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Data de Entrada";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.MintCream;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtualizar.Location = new System.Drawing.Point(1343, 35);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(133, 43);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnCadastroProdutos
            // 
            this.btnCadastroProdutos.BackColor = System.Drawing.Color.Teal;
            this.btnCadastroProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroProdutos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCadastroProdutos.Location = new System.Drawing.Point(1234, 656);
            this.btnCadastroProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.btnCadastroProdutos.Name = "btnCadastroProdutos";
            this.btnCadastroProdutos.Size = new System.Drawing.Size(122, 58);
            this.btnCadastroProdutos.TabIndex = 2;
            this.btnCadastroProdutos.Text = "Cadastro";
            this.btnCadastroProdutos.UseVisualStyleBackColor = false;
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.Teal;
            this.btnEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEstoque.Location = new System.Drawing.Point(1077, 656);
            this.btnEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(136, 58);
            this.btnEstoque.TabIndex = 1;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Teal;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSair.Location = new System.Drawing.Point(1377, 656);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(115, 58);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            // 
            // lbMesAtual
            // 
            this.lbMesAtual.AutoSize = true;
            this.lbMesAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMesAtual.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbMesAtual.Location = new System.Drawing.Point(486, 16);
            this.lbMesAtual.Name = "lbMesAtual";
            this.lbMesAtual.Size = new System.Drawing.Size(111, 25);
            this.lbMesAtual.TabIndex = 4;
            this.lbMesAtual.Text = "Mês Atual: ";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1530, 727);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.btnCadastroProdutos);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.chartMensal);
            this.Controls.Add(this.chartProdutos);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Arrecadação de Alimentos - Dashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMensal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalKilos;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Label lbTotalKg;
        private System.Windows.Forms.Label lbTotalItens;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProdutos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMensal;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnCadastroProdutos;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label lbMesAtual;
    }
}