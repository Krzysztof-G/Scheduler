using Scheduler.Common.Enums;
using Scheduler.Service.Models;
using System.Collections.Generic;

namespace Scheduler.Service.Interfaces
{
    /// <summary>
    /// Scheduled task service interface.
    /// </summary>
    public interface IScheduledTaskService
    {
        IEnumerable<ScheduledTaskDTO> GetTasksToDo();
        void SetTasksToErrorState(List<long> tasksToMarkAsErrorState);
        void SetTasksAsSucceded(List<long> tasksToMarkAsSucceded);
        void ScheduleTask(ScheduledTaskDTO newTask);
        void RepeatTaskAfter(ScheduledTaskDTO scheduledTask, ScheduledTaskOffsetTypes afterMinutes, int offsetValue);
    }
}
