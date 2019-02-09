using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPS
{
    public partial class frmCadastrarFuncionario : Form
    {
        //Referenciando classe mestre
        clsMestre objMestre = new clsMestre();

        public frmCadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            //Fechar formulário
            this.Close();
        }

        private void frmCadastrarFuncionario_Load(object sender, EventArgs e)
        {
            //Atribuindo cores de fundo
            pnlCadastrarFuncionario.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            btnPerfil.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            btnCadastrar.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());

            //Atribuindo cor de titulo
            btnPerfil.ForeColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appTituloCor"].ToString());
            btnCadastrar.ForeColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appTituloCor"].ToString());

            //Atribuindo cores de focus nos elementos
            txtNome.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtSobrenome.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEmail.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtRg.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEndereco.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtBairro.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtNumero.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtCidade.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEstado.LineFocusedColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());

            //Atribuindo cores de hover nos elementos
            txtNome.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtSobrenome.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEmail.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtRg.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEndereco.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtBairro.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtNumero.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtCidade.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
            txtEstado.LineMouseHoverColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());

        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlCelular.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        private void txtCelular_MouseHover(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlCelular.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus) para o padrao
            pnlCelular.BackColor = Color.Gray;
        }

        private void txtCarteiraTrabalho_Leave(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus) para o padrao
            pnlCarteiraTrabalho.BackColor = Color.Gray;
        }

        private void txtCarteiraTrabalho_Enter(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlCarteiraTrabalho.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus) para o padrao
            pnlCpf.BackColor = Color.Gray;
        }

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlCpf.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus) para o padrao
            pnlTelefone.BackColor = Color.Gray;
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlTelefone.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus) para o padrao
            pnlCep.BackColor = Color.Gray;

            //Consultar correio
            string cep = objMestre.ApenasNumeros(txtCep.Text);
            if (cep.Length == 8)
            {
                var ws = new wsCorreios.AtendeClienteClient();
                var resposta = ws.consultaCEP(cep);

                txtEndereco.Text = resposta.end;
                txtBairro.Text = resposta.bairro;
                txtCidade.Text = resposta.cidade;
                txtEstado.Text = resposta.uf;

            }
        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            //trocar a cor do painel (focus)
            pnlCep.BackColor = ColorTranslator.FromHtml(ConfigurationManager.AppSettings["appCor"].ToString());
        }

        //Carregar foto de perfil na picture box
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            string Furl = "";
            Path.ShowDialog();

            try
            {
                Furl = Path.FileName.ToString();
                pcbPerfil.Load(Furl);
            }
            catch
            {
                MessageBox.Show("Imagem não selecionada.");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Verificando se os campos estão nulos
            //Nome
            if (txtNome.Text.Replace(" ","") != "")
            {
                //Sobrenome
                if(txtSobrenome.Text.Replace(" ","") != "")
                {

                }
                else
                {
                    MessageBox.Show("Insira o sobrenome do funcionário");
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("Insira o nome do funcionário");
                txtNome.Focus();
            }
        }
    }
}
