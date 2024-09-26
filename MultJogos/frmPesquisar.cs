using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MultJogos
{
    public partial class frmPesquisar : Form
    {
        public frmPesquisar()
        {
            InitializeComponent();
        }
        private void frmPesquisar_Load(object sender, EventArgs e)
        {
             txtDescricao.Enabled = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // pesquisar por nome
        public void pesquisarPorCodigo(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where codFunc = @codFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codFunc", MySqlDbType.Int64).Value = codigo;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();
            //ltbPesquisar.Items.Clear();

            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(1));
            }


            Conexao.fecharConexao();
        }
        public void pesquisaPorNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome like '%"+nome+"%';";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(1));
            }

            Conexao.fecharConexao();
        }

        //pesquisar por nome
        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = ltbPesquisar.SelectedItem.ToString();
            frmFuncionarios abrir = new frmFuncionarios(nome);
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //if (rdbCodigo.Checked || rdbNome.Checked)
            //{
            //    ltbPesquisar.Items.Clear();
            //    ltbPesquisar.Items.Add(txtDescricao.Text);


            //    MessageBox.Show("Selecionado");
            //}
            //else
            //{
            //    MessageBox.Show("Não Selecionado");
            //}
            //pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
            if (rdbCodigo.Checked)
            {
                if (txtDescricao.Text != "")
                {
                    pesquisarPorCodigo(Convert.ToInt32(txtDescricao.Text));
                }
                
            }
            if (rdbNome.Checked)
            {
                if (txtDescricao.Text != "")
                {
                    pesquisaPorNome(txtDescricao.Text);
                }
            }
       
        }
        //Criando o método limpar
        public void limparCampos()
        {
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
            txtDescricao.Clear();
            ltbPesquisar.Items.Clear();
            txtDescricao.Enabled = false;
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpando os campos
            limparCampos();
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {

            txtDescricao.Enabled = true;
            txtDescricao.Focus();

            if (txtDescricao.Text.Equals(""))
            {
                MessageBox.Show("Digitar");
            }
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {

            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }
    }
}
