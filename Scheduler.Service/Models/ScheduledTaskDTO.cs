using Scheduler.Common.Enums;
using System;

namespace Scheduler.Service.Models
{
    /// <summary>
    /// Scheduled task DTO
    /// </summary>
    public class ScheduledTaskDTO
    {
        public long ScheduledTaskId { get; set; }
        public DateTime PlannedExecutionDate { get; set; }
        public DateTime CreationDate { get; set; }
        public long? RelatedObjectId { get; set; }
        public RelatedObjectTypes RelatedObjectType { get; set; }
        public ScheduledTaskStates ScheduledTaskState { get; set; }
        public ScheduledTaskTypes ScheduledTaskType { get; set; }
    }
}
