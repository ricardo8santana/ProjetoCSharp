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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            buscarFuncionarios();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //método para buscar Funcionarios
        public void buscarFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios order by nome;";
            comm.CommandType = CommandType.Text;

          
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();
            while (DR.Read())
            {
                cbbFuncionario.Items.Add(DR.GetString (1));
            }
           
            Conexao.fecharConexao();

        }
        //Método para buscar funcionarios por nome e pegar o codigo
        public void buscarFuncionariosNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome = @nome;";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = nome;

            MySqlDataReader DR;

            DR = comm.ExecuteReader();
            DR.Read();
            lblMostrarCodigo.Text = DR.GetInt32(0).ToString();

            Conexao.fecharConexao();

        }
        public void buscaUsuariosFuncionarios(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select usu.nome from tbUsuarios as usu inner join tbFuncionarios as func on usu.codfunc = func.codfunc where @func.nome; ";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@func.nome", MySqlDbType.VarChar, 50).Value = nome;
            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
          
            DR.Read();
            try
            {
                txtUsuario.Text = DR.GetString(0);
            }
            catch(Exception)
            {
                MessageBox.Show("Usuario não encontrado");
                txtUsuario.Clear();
                txtUsuario.Enabled = true;
                txtSenha.Enabled = true;
                txtSenhaValida.Enabled = true;
                txtUsuario.Focus();
            }

            Conexao.fecharConexao();
        }

        private void cbbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarFuncionariosNome(cbbFuncionario.SelectedItem.ToString());
            buscaUsuariosFuncionarios(cbbFuncionario.SelectedItem.ToString());

        }

        //cadastrar usuarios
        public void cadastrarUsuarios(string nome, string senha, int codFunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into  tbUsuarios(nome, senha,codFunc) values(@nome, @senha, @codFunc);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 30).Value = nome ;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = senha;
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32, 11).Value = codFunc;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            Conexao.fecharConexao();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadastrarUsuarios(txtUsuario.Text,txtSenha.Text, Convert.ToInt32(lblMostrarCodigo.Text));
        }

        private void lblMostrarCodigo_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }
    }
}
