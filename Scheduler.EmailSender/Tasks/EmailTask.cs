using System.Collections.Generic;
using System.Linq;
using Autofac;
using Scheduler.Common.Enums;
using Scheduler.EmailSender.Helpers.DependencyInjection;
using Scheduler.EmailSender.Interfaces;
using Scheduler.EmailSender.Models;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;

namespace Scheduler.EmailScheduler.Tasks
{
    /// <summary>
    /// Email class
    /// </summary>
    public abstract class EmailTask
    {
        /// <summary>
        /// User service instance.
        /// </summary>
        protected IUserService UserService;

        /// <summary>
        /// Initialize a new instance of <see cref="EmailTask"/> class.
        /// </summary>
        public EmailTask()
        {
            UserService = Resolver.Container.Resolve<IUserService>();
        }

        /// <summary>
        /// Email type.
        /// </summary>
        public abstract EmailTypes Type { get; }

        /// <summary>
        /// Gets subject of email.
        /// </summary>
        /// <returns>Subject of email.</returns>
        public abstract string GetSubject();

        /// <summary>
        /// Gets body of email.
        /// </summary>
        /// <param name="recipient">Email recipient.</param>
        /// <param name="relatedObjectId">Related object id.</param>
        /// <returns>Body of email.</returns>
        public abstract string GetBody(UserDTO recipient, long relatedObjectId);

        /// <summary>
        /// Gets recipients of email.
        /// </summary>
        /// <param name="relatedObjectId">Related object id.</param>
        /// <returns>Recipients of email.</returns>
        public abstract List<UserDTO> GetRecipients(long relatedObjectId);

        /// <summary>
        /// Send an email.
        /// </summary>
        /// <param name="email">Email to send.</param>
        public void Send(EmailDTO email)
        {
            IEmailService emailService = Resolver.Container.Resolve<IEmailService>();

            List<UserDTO> recipients = GetRecipients(email.RelatedObjectId);

            if ((bool)recipients?.Any())
            {
                foreach (var recipient in recipients)
                {
                    EmailMessage emailMessage = new EmailMessage
                    {
                        Subject = GetSubject(),
                        Body = GetBody(recipient, email.RelatedObjectId),
                        Recipent = recipient,
                    };
                    emailService.SendEmail(emailMessage);
                }
            }
            else
            {
                //TODO Add exception handling.
            }
        }
    }
}