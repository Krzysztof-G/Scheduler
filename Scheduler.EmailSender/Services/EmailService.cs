using Scheduler.Common.Helpers;
using Scheduler.EmailSender.Interfaces;
using Scheduler.EmailSender.Models;
using System;
using System.Net.Mail;
using System.Text;

namespace Scheduler.EmailSender.Services
{
    /// <summary>
    /// Email service instance.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// SMTP Client
        /// </summary>
        private SmtpClient smtpClient = new SmtpClient(Constants.SchedulerSMTPHost, Constants.SchedulerSMTPPort);

        /// <summary>
        /// Encoding of the email messages.
        /// </summary>
        private Encoding encoding = Constants.SchedulerEncodingOfEmailMessages;

        #region Public Methods

        /// <summary>
        /// Send an email.
        /// </summary>
        /// <param name="emailMessage">Email to send.</param>
        public void SendEmail(EmailMessage emailMessage)
        {
            MailAddress emailSender = new MailAddress(Constants.SchedulerSenderEmailAddress, Constants.SchedulerSenderName, encoding);
            MailAddress emailRecipent = new MailAddress(emailMessage.Recipent.Email, emailMessage.Recipent.UserName, encoding);
            MailMessage message = new MailMessage(emailSender.ToString(), emailRecipent.ToString(), emailMessage.Subject, emailMessage.Body);
            message.IsBodyHtml = true;
            SetEncodingMailMessage(message);
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                //TODO Add exception handling.
            }
            finally
            {
                message.Dispose();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Set encoding of whole email message.
        /// </summary>
        /// <param name="message">Email message.</param>
        private void SetEncodingMailMessage(MailMessage message)
        {
            message.SubjectEncoding = encoding;
            message.HeadersEncoding = encoding;
            message.BodyEncoding = encoding;
        }

        #endregion Private Methods
    }
}
