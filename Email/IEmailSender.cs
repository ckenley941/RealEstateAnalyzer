using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RealEstateAnalyzer.Emailing
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailMessage mailMessage);
    }
}
