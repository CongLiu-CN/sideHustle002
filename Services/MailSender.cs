using AngularJS_Proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AngularJS_Proj.Services
{
    public class MailSender
    {
        public MailSender()
        {

        }

        public void SendMail(ContactModel userInfo)
        {
            try
            {
                var mailbody = $@"Hello Dr Wang,
            This is a new contact request from your website:
            Name: {userInfo.Name}
            Email: {userInfo.Email}
            Type: {userInfo.Session}
            Message: ""{userInfo.Message}""";

                using (var message = new MailMessage(userInfo.Email, "kwacupuncture@gmail.com"))
                {
                    message.To.Add(new MailAddress("kwacupuncture@gmail.com"));
                    message.From = new MailAddress(userInfo.Email);
                    message.Subject = "New E-Mail from my website";
                    message.Body = mailbody;


                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("", "");
                    
                    smtpClient.Send(message);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
