﻿using ASC.Web.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace ASC.Web.Service
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private IOptions<ApplicationSettings> _settings;
        public AuthMessageSender(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_settings.Value.SMTPAccount));
            emailMessage.To.Add(new MailboxAddress(email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_settings.Value.SMTPServer, _settings.Value.
                SMTPPort, false);
                await client.AuthenticateAsync(_settings.Value.SMTPAccount, _settings.Value.
                SMTPPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
