using RealEstateAnalyzer.Emailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Notifications.Processes
{
    public class SendIncidentReport : ISendIncidentReport
    {
        private readonly IEmailSender _emailSender;

        public SendIncidentReport(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Run()
        {
            //MailMessage mailMessage = new MailMessage
            //{
            //    From = new MailAddress("ckenley@verisk.com")
            //};
            //mailMessage.To.Add("ckenley941@gmail.com");
            //mailMessage.Body = "body";
            //mailMessage.Subject = "subject";
            //_emailSender.SendEmailAsync(mailMessage);
            return Task.CompletedTask;
        }
    }
}
