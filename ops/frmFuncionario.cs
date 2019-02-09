using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPS
{
    public partial class frmFuncionario : Form
    {
        //Instanciando classe mestre
        clsMestre objMestre = new clsMestre();
        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            //Atribuindo cores de fundo
            pnlFuncionario.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            btnCadastrar.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            //Atribuindo cores de texto
            btnCadastrar.ForeColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appTituloCor"].ToString());

            //encher data grid
            string sql = "SELECT Nome, Sobrenome, Sexo, Cpf, Email, Celular, Cidade, Estado, Ativo FROM vw_Funcionarios;";
            dgvFuncionario.DataSource = (objMestre.SelectTabela(sql));
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Abrir tela de cadastro de funcionario
            frmCadastrarFuncionario frm = new frmCadastrarFuncionario();
            frm.ShowDialog();
        }

        private void dgvFuncionario_DoubleClick(object sender, EventArgs e)
        {
            string funcionario = dgvFuncionario.CurrentRow.Cells[0].Value.ToString();

            if (funcionario != "")
            {
                MessageBox.Show(funcionario);
            }
        }
    }
}
