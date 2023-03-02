using RealEstateAnalyzer.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Emailing
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _env;

        public EmailSender(IOptions<EmailSettings> emailSettings, IHostingEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;
        }

        public Task SendEmailAsync(MailMessage mailMessage) //Will eventually want DTO passed so other projects don't need to be tied to System.Net.Mail
        {
            //using (SmtpClient client = new SmtpClient())
            //{
            //    client.DeliveryMethod = _emailSettings.DeliveryMethod.ToEnum<SmtpDeliveryMethod>();
            //    client.Timeout = _emailSettings.Timeout;
            //    client.Host = _emailSettings.MailServer;
            //    client.Port = _emailSettings.MailPort;
            //    client.UseDefaultCredentials = _emailSettings.UseDefaultCredentials;
            //    client.EnableSsl = _emailSettings.EnableSsl;
            //    client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

            //    client.Send(mailMessage);
            //}
            return Task.CompletedTask;
        }
    }
}
