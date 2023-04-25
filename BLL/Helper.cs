using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Helper
    {
        private readonly IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //generic methord to send email from the application
        //config values saved in appsettings.json
        public void SendEmail(string htmlString,string subject, List<string> users)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                string fromEmail = _configuration.GetValue<string>("notificationMail");
                string fromEmailSecretpass = _configuration.GetValue<string>("notificationMailKey");
                message.From = new MailAddress(fromEmail);
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = _configuration.GetValue<string>("emailhost");
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromEmailSecretpass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                foreach (var email in users)
                {
                    message.To.Add(new MailAddress(email));
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
