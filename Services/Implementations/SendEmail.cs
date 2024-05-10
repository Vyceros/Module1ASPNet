using ITStepRazorApp.Data.Model;
using ITStepRazorApp.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace ITStepRazorApp.Services.Implementations
{
    public class SendEmail : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public SendEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email,string subject,string message)
        {
            var options = _configuration.GetSection("Credentials").Get<EmailSenderOptions>();
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(options.Email,options.Password)
            };
            
            var mailBody = new MailMessage(from: options.Email,
                to: email,
                subject,
                message);

            mailBody.IsBodyHtml = true;

            return client.SendMailAsync(mailBody);
        }
    }
}
