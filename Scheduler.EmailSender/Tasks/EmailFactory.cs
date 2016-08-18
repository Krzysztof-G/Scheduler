using Scheduler.Common.Enums;
using System;
using System.Collections.Generic;
using Scheduler.EmailScheduler.Tasks.Instances;

namespace Scheduler.EmailScheduler.Tasks
{
    /// <summary>
    /// Email factory class.
    /// </summary>
    public class EmailFactory
    {
        /// <summary>
        /// Email (products) dictionary.
        /// </summary>
        private static Dictionary<EmailTypes, Func<EmailTask>> emailFactories = new Dictionary<EmailTypes, Func<EmailTask>>()
        {
            { EmailTypes.TestEmail, () => new TestEmail() },
        };

        /// <summary>
        /// Gets email by type.
        /// </summary>
        /// <param name="type">Type of email.</param>
        /// <returns><see cref="EmailTask"/> instance.</returns>
        public static EmailTask GetEmail(EmailTypes type)
        {
            return emailFactories[type]();
        }
    }
}
