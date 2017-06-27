using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DPEP.Common.BLL.Methods
{
    public class SendEmail
    {
        private readonly EmailDaemon _emailDaemon;
        public SendEmail(EmailDaemon emailDaemon)
        {
            _emailDaemon = emailDaemon;

        }
        public async Task SendNow(string subject, string messagebody, string senderEmail, bool withTemplate, string FullName, string link, string uri, string date, string time, string message)
        {
            await _emailDaemon.SendEmailAsync(subject, messagebody, senderEmail);
        }
    }
}
