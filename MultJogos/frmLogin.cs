using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultJogos
{
    public partial class frmLogin : Form
    {
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
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //criando variáveis
            string usuario, senha;

            //inicializar as variáveis
            usuario = textUsuario.Text;
            senha = textSenha.Text;

            if (usuario.Equals("senac")&&senha.Equals("senac"))
            {
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
                this.Hide();
            }





            //MessageBox.Show("Bem vindo ao sistema.","Sistema",
            //    MessageBoxButtons.YesNoCancel,
            //    MessageBoxIcon.Error,
            //    MessageBoxDefaultButton.Button1);

        }
    }
}
