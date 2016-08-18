using Scheduler.Common.Enums;
using Scheduler.Core.Tasks.Types;
using System;

namespace Scheduler.Tasks.Instances
{
    public class SendTestEmailTask : EmailTaskType
    {
        public override ScheduledTaskTypes Type
        {
            get
            {
                return ScheduledTaskTypes.SendTestEmail;
            }
        }

        public override void ScheduleTask(long? userId)
        {
            if (userId == null)
                throw new ArgumentNullException();

            Scheduling(userId, DateTime.Now);
        }
    }
}
