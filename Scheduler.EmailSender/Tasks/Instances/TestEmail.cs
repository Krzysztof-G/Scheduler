using Scheduler.Common.Enums;
using Scheduler.EmailSender.Resources;
using Scheduler.EmailSender.Templates;
using Scheduler.EmailSender.Templates.ViewModels;
using Scheduler.Service.Models;
using System;
using System.Collections.Generic;

namespace Scheduler.EmailScheduler.Tasks.Instances
{
    public class TestEmail : EmailTask
    {
        public override EmailTypes Type
        {
            get
            {
                return EmailTypes.TestEmail;
            }
        }

        public override string GetSubject()
        {
            return EmailLabels.TestEmailSubject;
        }

        public override string GetBody(UserDTO recipient, long relatedObjectId)
        {
            var model = new TestEmailViewModel
            {
                RecipientName = recipient.UserName,
                CreationDate = DateTime.Now
            };
            return RazorTemplateManager.GenerateEmailBody(model, Type);
        }

        public override List<UserDTO> GetRecipients(long userId)
        {
            return new List<UserDTO> { UserService.GetUserById(userId) };
        }
    }
}
