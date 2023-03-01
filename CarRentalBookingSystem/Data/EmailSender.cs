using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using Castle.Core.Smtp;
using CarRentalBookingSystem.Model;

namespace CarRentalBookingSystem.Data
{

    //public class EmailSender : IEmailSender
    //{
    //    private readonly EmailSenderOptions _options;

    //    public EmailSender(IOptions<EmailSenderOptions> options)
    //    {
    //        _options = options.Value;
    //    }

    //    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        var smtpClient = new SmtpClient
    //        {
    //            Host = _options.SmtpHost,
    //            Port = _options.SmtpPort,
    //            EnableSsl = _options.UseSsl,
    //            Credentials = new NetworkCredential(_options.SmtpUsername, _options.SmtpPassword)
    //        };

    //        var mailMessage = new MailMessage
    //        {
    //            From = new MailAddress(_options.FromEmail),
    //            Subject = subject,
    //            Body = htmlMessage,
    //            IsBodyHtml = true
    //        };

    //        mailMessage.To.Add(email);

    //        return smtpClient.SendMailAsync(mailMessage);
    //    }
    //}
}