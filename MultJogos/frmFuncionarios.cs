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
using MosaicoSolutions.ViaCep;

namespace MultJogos
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);
        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
        }
        //IntPtr hMenu = GetSystemMenu(this.Handle, false);
        //int MenuCount = GetMenuItemCount(hMenu) - 1;
        //RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();
        }
        //método para desabilitar os campos e botões
        public void desabilitarCampos()
        {
            textCodigo.Enabled = false;
            textEndereco.Enabled = false;
            textNome.Enabled = false;
            txtEmail.Enabled = false;
            textBairro.Enabled = false;
            txtCidade.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            textNumero.Enabled = false;
            // btnCadastrar.Enabled = false;
        } //método para habilitar os campos e botões
        public void habilitarCampos()
        {
            textCodigo.Enabled = true;
            textEndereco.Enabled = true;
            textNome.Enabled = true;
            txtEmail.Enabled = true;
            textBairro.Enabled = true;
            txtCidade.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            //btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;
            btnCadastrar.Enabled = true;
            textNumero.Enabled = true;

            textNome.Focus();
        }
        //método para limpar campos
        public void limparCampos()
        {
            textCodigo.Clear();
            textEndereco.Clear();
            textNome.Clear();
            txtEmail.Clear();
            textBairro.Clear();
            txtCidade.Clear();
            mskCEP.Clear();
            mskCPF.Clear();
            mskTelefone.Clear();
            textNumero.Clear();
            cbbEstado.Text = "";
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnCadastrar.Enabled = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (textNome.Text.Equals("") || txtEmail.Text.Equals("")
                || textEndereco.Text.Equals("")
                || textBairro.Text.Equals("")
                || txtCidade.Text.Equals("")
                || mskCEP.Text.Equals("     ")
                || mskCPF.Text.Equals("   .   .   -")
                || mskTelefone.Text.Equals("     - ")
                || cbbEstado.Text.Equals(""))
            {
                MessageBox.Show("Não deixar campos vazios.");
                textNome.Focus();
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso!!!");
                desabilitarCampos();
            }
        }
        public void buscarCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            try
            {
                var endereco = viaCEPService.ObterEndereco(cep);
                textEndereco.Text = endereco.Logradouro;
                textBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Localidade;
                cbbEstado.Text = endereco.UF;
            }
            catch (Exception)
            {
                MessageBox.Show("CEP não econtrado!!.");
                mskCEP.Focus();
            }
          
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarCEP(mskCEP.Text);
                textNumero.Focus();
            }
            //else
            //{
            //    MessageBox.Show("CEP não encontrado!!.");
            //    textEndereco.Focus();
            //}
        }

        private void textNumero_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}