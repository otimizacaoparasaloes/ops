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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Carregando nome da aplicação
            lblAplicacaoNome.Text = ConfigurationManager.AppSettings["appNome"].ToString();
            
            //Atribuindo cores de fundo
            btnFechar.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            btnMinimizar.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            pnlTop.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            //Atribuindo cores de texto
            lblAplicacaoNome.ForeColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appTituloCor"].ToString());

            //Atribuindo cor de hover nos botões
            btnFuncionario.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());       


        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            //Fechar aplicação
            if (MessageBox.Show("Deseja sair?", "Sair", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            //Minimizar aplicação
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFuncionario frm = new frmFuncionario();
            frm.TopLevel = false;
            pnlForms.Controls.Clear();
            pnlForms.Controls.Add(frm);
            frm.Show();
        }

    }
}
