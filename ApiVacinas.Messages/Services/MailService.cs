using ApiVacinas.Messages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Messages.Services
{
    /// <summary>
    /// Classe para serviço de envio de email
    /// </summary>
    public class MailService
    {
        //atributo
        private readonly MailSettings _mailSettings;

        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        //metodo para realizar o envio de email
        public void SendMail(string to, string subject, string body)
        {
            #region Criando o conteúdo do email

            var mailMessage = new MailMessage(_mailSettings.Conta, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            #endregion

            #region Enviando o email

            var smtpClient = new SmtpClient(_mailSettings.Smtp, _mailSettings.Porta);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_mailSettings.Conta, _mailSettings.Senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            #endregion
        }
    }
}
