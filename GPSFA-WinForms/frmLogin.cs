using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace GPSFA_WinForms
{
    public partial class frmLogin : Form
    {
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);


        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario, senha;
            
            usuario = txtUsuario.Text.Trim();
            senha = txtSenha.Text.Trim();

            if (validarUsuarios (usuario, senha))
            {
                frmMenuPrincipal abrir  = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", 
                    "Mensagem do sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                //métdo para limpar os campos de texto
                limparCampos();

            }
        }

        public void limparCampos()
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu) -1;
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYCOMMAND);
        }

        //validar os usuários no banco de dados
        public bool validarUsuarios(string usuario, string senha)
        {
            string sql = "SELECT 1 FROM tbUsuarios WHERE usuario = @usuario AND senha = @senha LIMIT 1";

            using (MySqlConnection conexao = DataBaseConnection.OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.Add("@usuario", MySqlDbType.VarChar, 100).Value = usuario;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 100).Value = senha;

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    return dr.HasRows;
                }
            }
        }
    }
}
