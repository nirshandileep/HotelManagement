using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace HBM.Utility
{
    public class Mail
    {
        /// <summary>
        /// Gets or sets From Email
        /// </summary>
        public string FromEmail { get; set; }
        
        /// <summary>
        /// Gets or sets To Email
        /// </summary>
        public string ToEmails { get; set; }

        /// <summary>
        /// Gets or sets Subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets SMTP client
        /// </summary>
        public string SMTPClient { get; set; }

        /// <summary>
        /// Sending Email
        /// </summary>
        /// <returns>True if success</returns>
        public bool Send()
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(this.ToEmails);
                mailMessage.From = new MailAddress(this.FromEmail);
                mailMessage.Subject = this.Subject;
                mailMessage.Body = this.Body;
                SmtpClient smtpClient = new SmtpClient(this.SMTPClient);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
