using System;
using System.Net;
using System.Net.Mail;
using SOS.Dentes.DAL;
using SOS.Dentes.Model;

namespace SOS.Dentes.BLL
{
    public class ContatoBLL
    {
        private ContatoDAL dal;
        public ContatoBLL()
        {
            this.dal = new ContatoDAL();
        }
        public void create(Contato model)
        {
            //dal.create(model);
            SendEmail(model);
        }

        private void SendEmail(Contato model)
        {
            //Define os dados do e-mail
            string nomeRemetente = ObterChaveConfigurada("REMETENTE_NOME");
            string emailRemetente = ObterChaveConfigurada("REMETENTE");
            string senhaRemetente = ObterChaveConfigurada("REMETENTE_SENHA");
            string emailDestinatario = ObterChaveConfigurada("DESTINATARIO");
            string assuntoMensagem = ObterChaveConfigurada("ASSUNTO");
            string conteudoMensagem = string.Format(
                @"<p><b>Nome: </b>{0}</p>" +
                @"<p><b>Avaliação: </b>{1}</p>" +
                @"<p><b>E-Mail: </b>{2}</p>" +
                @"<p><b>Telefone: </b>{3}</p>" +
                @"<p><b>Mensagem: </b>{4}</p>"
                , model.Nome, model.Avaliacao, model.Email, model.Telefone, model.Mensagem);

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            objEmail.To.Add(emailDestinatario);

            //Define a prioridade do e-mail.
            objEmail.Priority = MailPriority.Normal;

            //Define o formato do e-mail html (caso nao queira html alocar false)
            objEmail.IsBodyHtml = true;

            //Define titulo do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "UFT-8"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");

            objEmail.From = new MailAddress(emailRemetente, nomeRemetente);


            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential(emailRemetente, senhaRemetente);

                // envia o e-mail
                smtp.Send(objEmail);
            }
        }

        private string ObterChaveConfigurada(string chave)
        {
            return System.Configuration.ConfigurationManager.AppSettings[chave] ?? string.Empty;
        }
    }
}












