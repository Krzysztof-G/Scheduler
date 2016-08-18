using System.ComponentModel;

namespace Scheduler.Common.Enums
{
    /// <summary>
    /// Analyse types
    /// </summary>
    public enum EmailTypes
    {
        TestEmail = 1,
    }

    public static class EmailTypesExtensions
    {
        public static EmailTypes ToEmailType(this ScheduledTaskTypes source)
        {
            switch (source)
            {
                case ScheduledTaskTypes.SendTestEmail:
                    return EmailTypes.TestEmail;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
