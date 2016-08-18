using System.Text;

namespace Scheduler.Common.Helpers
{
    public static class Constants
    {
        #region Scheduler

        /// <summary>
        /// Interval between scheduler work(in minutes).
        /// </summary>
        public const int SchedulerIntervalBetweenWorkInMinutes = 1;

        /// <summary>
        /// Directory contains email templates views.
        /// </summary>
        public const string SchedulerEmailTemplatesViewsDirectory = "Templates\\Views";

        /// <summary>
        /// SMTP host used to send emails.
        /// </summary>
        public const string SchedulerSMTPHost = "localhost";

        /// <summary>
        /// SMTP port used to send emails.
        /// </summary>
        public const int SchedulerSMTPPort = 25;

        /// <summary>
        /// Email sender Name.
        /// </summary>
        public const string SchedulerSenderName = "SchedulerKG";

        /// <summary>
        /// Email sender address.
        /// </summary>
        public const string SchedulerSenderEmailAddress = "temp@temp.pl";

        /// <summary>
        /// Encoding of emails messages.
        /// </summary>
        public static Encoding SchedulerEncodingOfEmailMessages { get; } = Encoding.UTF8;

        #endregion Scheduler
    }
}
