using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using UserCRUDandJWT.Models;
using UserCRUDandJWT.Services.Interfaces;

namespace UserCRUDandJWT.Services.Implementations { 

public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        private async Task SendAsync(string to, string subject, string body)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_settings.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(to);

            using var smtp = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.Username,
                    _settings.Password
                ),
                EnableSsl = _settings.EnableSsl
            };

            await smtp.SendMailAsync(mail);
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string username)
        {
            await SendAsync(
                toEmail,
                "Welcome to User Auth 🎉",
                $"""
            <h2>Hello {username},</h2>
            <p>Your account has been successfully created.</p>
            <p>Welcome aboard 🚀</p>
            """
            );
        }

        public async Task SendLoginEmailAsync(string toEmail, string username)
        {
            await SendAsync(
                toEmail,
                "Login Alert 🔐",
                $"""
            <h3>Hello {username},</h3>
            <p>You have just logged in to your account.</p>
            <p>If this wasn't you, please secure your account immediately.</p>
            """
            );
        }
    }


}

