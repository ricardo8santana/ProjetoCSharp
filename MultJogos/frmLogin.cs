using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace MultJogos
{
    public partial class frmLogin : Form
    {
        //Criando variáveis para controle do menu
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
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //criando variáveis
            string usuario, senha;

            //inicializar as variáveis
            usuario = textUsuario.Text;
            senha = textSenha.Text;

            //validando a entrada do usuário
             if (usuario.Equals("senac")&&senha.Equals("senac"))
            {
                //entrar no sistema
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario ou senha inválidos.", "Sistema",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
                //executando o método limpar campos
                limparCampos();

            }
        }
        //Limpar o método limpar campos
        public void limparCampos()
        {
            textUsuario.Clear();
            textSenha.Text = "";
            textUsuario.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void textSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSenha.Focus();
            }
        }

        private void textUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String conexao = "server=localhost;port=3306;database=dbti112;uid=senacti112;pwd=123456";
            //MySqlConnection conn = new MySqlConnection(conexao);
            //conn.Open();
            Conexao.obterConexao();
            MessageBox.Show("Banco de Dados conectado");
            Conexao.fecharConexao();
            //conn.Close();

        }

        private void btnConectar_Cick(object sender, EventArgs e)
        {

        }
    }
}
