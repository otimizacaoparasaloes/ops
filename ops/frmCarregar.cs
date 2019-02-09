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
    public partial class frmCarregar : Form
    {
        //Instanciar classe mestre
        clsMestre objMestre = new clsMestre();

        public frmCarregar()
        {
            InitializeComponent();
        }

        private void frmCarregar_Load(object sender, EventArgs e)
        {
        }

        private void tmrCarregar_Tick(object sender, EventArgs e)
        {
            if (pgbCarregar.Value < 100)
            {
                /* Carregando progress bar */
                pgbCarregar.Value += 2;

                /* Atribuindo mensagens ao longo do load */
                if (pgbCarregar.Value >= 0  && pgbCarregar.Value < 20)
                {
                    //Validando data de vencimento
                    lblCarregar.Text = "Validando dados ...";
                }
                else if (pgbCarregar.Value == 20)
                {
                    //Verificando a conexão com o banco de dados
                    if (objMestre.TestarConexao() == false)
                    {
                        MessageBox.Show("Erro ao conectar banco de dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        lblCarregar.Text = "Conectando ao banco de dados ...";
                    }
                }
                else if (pgbCarregar.Value >= 40 && pgbCarregar.Value < 80)
                {
                    lblCarregar.Text = "Configurando aplicativo ...";
                }
                else if (pgbCarregar.Value == 80)
                {
                    //Testar conexão com a internet
                    if (objMestre.Ping(ConfigurationManager.AppSettings["appPing"].ToString()) == true)
                    {
                        lblCarregar.Text = "Conectando a internet ...";
                    }
                    else
                    {
                        MessageBox.Show("Erro ao conectar com a internet!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (pgbCarregar.Value > 90)
                {
                    //Mensagem de bem vindo
                    lblCarregar.Text = "Bem vindo !";
                }
            }
            //Final do timer
            else
            {
                //desabilitando timer
                tmrCarregar.Enabled = false;

                //Chamar nova janela
                frmPrincipal objPrincipal = new frmPrincipal();
                objPrincipal.Show();

                //Fechando janela
                this.Hide();
            }
        }
    }
}
