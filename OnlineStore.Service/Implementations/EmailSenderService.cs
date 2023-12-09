using OnlineStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Implementations
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subjet, string massenge)
        {
            var mail = "huntandfishdylo@gmail.com";
            var pw = "T!est123123123";

            var client = new SmtpClient("smtp.example.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subjet, massenge));
        }
    }
}
