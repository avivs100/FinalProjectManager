using System.Net.Mail;
using System.Net;

namespace FinalProjectManger_server.Services
{
    public class EmailService
    {

        public void SendEmail(string from, string to, string subject, string msg)
        {
            try
            {
                var message = new MailMessage();
                var smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                //message.IsBodyHtml = true;  
                message.Body = msg;
                smtp.Port = 587;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FinalProjectManager@outlook.com", "AaSs2804");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
