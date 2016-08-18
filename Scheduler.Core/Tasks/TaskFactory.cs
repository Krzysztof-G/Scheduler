using Scheduler.Common.Enums;
using Scheduler.Core.Types.Tasks;
using Scheduler.Tasks.Instances;
using System;
using System.Collections.Generic;

namespace Scheduler.Tasks
{
    /// <summary>
    /// Scheduled task factory class.
    /// </summary>
    public class ScheduledTaskFactory
    {
        /// <summary>
        /// Scheduled task (products) dictionary.
        /// </summary>
        private static Dictionary<ScheduledTaskTypes, Func<ScheduledTaskBase>> taskFactories = new Dictionary<ScheduledTaskTypes, Func<ScheduledTaskBase>>()
        {
            { ScheduledTaskTypes.SendTestEmail, () => new SendTestEmailTask() },
        };

        /// <summary>
        /// Gets scheduled task by type.
        /// </summary>
        /// <param name="type">Type of task.</param>
        /// <returns><see cref="ScheduledTaskBase"/> instance.</returns>
        public static ScheduledTaskBase GetTask(ScheduledTaskTypes type)
        {
            return taskFactories[type]();
        }
    }
}
