using DPEP.Common.DAL.Model;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Methods
{
    public class EmailDaemon
    {
        private readonly IOptions<AppSettingModel> _options;

        public EmailDaemon(IOptions<AppSettingModel> options)
        {
            _options = options;
        }

        public async Task SendEmailAsync(string subject, string body, string recipient)
        {

            var emailMessage = new MimeMessage
            {
                From = {
                    new MailboxAddress("Devpartners", _options.Value.SenderEmail)
                },
                To = {
                    new MailboxAddress("DevPartners", recipient)
                },
                Subject = subject,
                Body = new TextPart("html")
                {
                    Text = body
                }
            };

            using (var client = new SmtpClient())
            {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_options.Value.SenderEmail, _options.Value.Password);

                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

        }
    }
}
