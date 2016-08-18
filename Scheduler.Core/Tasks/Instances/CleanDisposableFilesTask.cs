using Scheduler.Common.Enums;
using Scheduler.Core.Tasks.Types;
using System;
using Scheduler.Service.Models;

namespace Scheduler.Tasks.Instances
{
    public class CleanDisposableFilesTask : EmailTaskType
    {
        public override ScheduledTaskTypes Type
        {
            get
            {
                return ScheduledTaskTypes.CleanDisposableFiles;
            }
        }

        public override void ScheduleTask(long? analysedDirectory)
        {
            if (analysedDirectory == null)
                throw new ArgumentNullException();

            Scheduling(analysedDirectory, DateTime.Now);
        }

        protected override void ScheduleNewTask(ScheduledTaskDTO scheduledTask)
        {
            Scheduling(scheduledTask.RelatedObjectId, DateTime.Now.AddHours(1));
        }
    }
}
