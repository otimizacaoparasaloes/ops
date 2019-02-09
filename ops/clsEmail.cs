
using System;
using System.Configuration;
using System.Net.Mail;

namespace OPS
{
    class clsEmail
    {
        //Função para mandar E-mail
        public bool EnviarEmail(OpcaoEmail opcao, string para, string assunto, string mensagem)
        {
            //Instanciando variaveis
            SmtpClient objSmtp = new SmtpClient();
            MailMessage objEmail = new MailMessage();
            string assinatura = "", nomeDeEnvio = "", html;

            //Definir o nome de quem está enviando a mensagem
            nomeDeEnvio = ConfigurationManager.AppSettings["appNome"].ToString() + " - ";
            if (opcao == OpcaoEmail.Sistema) { nomeDeEnvio += "System"; }
            if (opcao == OpcaoEmail.Suporte) { nomeDeEnvio += "Support"; }
            if (opcao == OpcaoEmail.Seguranca) { nomeDeEnvio += "Security"; }

            //Montando assinatura do E-mail
            assinatura = "<br/> <br/>";
            assinatura += "Mensagem enviada automaticamente por ";
            assinatura += nomeDeEnvio;
            assinatura += ", por favor não responda este e-mail. ";

            //Montando html do e-mail
            html = "<html>";
            //Cabeçalho
            html += "   <head>";
            html += "		<meta charset='utf - 8'>";
            html += "		<title>" + ConfigurationManager.AppSettings["appNome"].ToString() + "</title>";
            html += "       <style>";
            html += "               .conteudo,.rodape,.title{padding:20px}body{font-family:arial}.container{width:100%;border-radius:20px;background-color:#f2f2f2}.title{color:#fff;background-color:#80bdff;border-top-left-radius:20px;border-top-right-radius:20px}.conteudo{min-height:250px}.rodape{text-align:center;border-top:1px solid rgba(0,0,0,.05);margin-bottom:0}";
            html += "       </style>";
            html += "	</head>";
            //Corpo
            html += "	<body>";
            html += "		<div class='container'>";
            html += "			<h3 class='title'>" + ConfigurationManager.AppSettings["appNome"].ToString() + "</h3>";
            html += "			<div class='conteudo'>";
            html += "				<p>" + mensagem + assinatura + "</p>";
            html += "			</div>";
            html += "			<div class='rodape'>";
            html += "					<small> &copy " + ConfigurationManager.AppSettings["appNome"].ToString() + " - " + DateTime.Now.Year + "</small>";
            html += "			</div>";
            html += "		</div>";
            html += "	</body>";
            html += "</html>";

            //Configurações do E-mail
            objEmail.From = new MailAddress(ConfigurationManager.AppSettings["emailUsuario"].ToString(), nomeDeEnvio);
            objEmail.Subject = assunto;
            objEmail.Body = html;
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.To.Add(para);

            //Enviando E-mail
            try
            {
                System.Net.NetworkCredential objCredentials = new System.Net.NetworkCredential();
                objCredentials.Password = ConfigurationManager.AppSettings["emailSenha"].ToString();
                objCredentials.UserName = ConfigurationManager.AppSettings["emailUsuario"].ToString();
                objSmtp.UseDefaultCredentials = false;
                objSmtp.Credentials = objCredentials;
                objSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtp.EnableSsl = true;
                objSmtp.Port = int.Parse(ConfigurationManager.AppSettings["emailSmtpPorta"].ToString());
                objSmtp.Host = ConfigurationManager.AppSettings["emailSmtpHost"].ToString();
                objSmtp.Send(objEmail);
                return true;
            }
            catch (Exception ex)
            {
                //Tratamento de erro            
                return false;
            }
        }
    }

    // Enum para funções -----------------------------------------------------------------------------------------------------------------

    //Envio de e-mail
    public enum OpcaoEmail { Sistema, Suporte, Seguranca };
}

