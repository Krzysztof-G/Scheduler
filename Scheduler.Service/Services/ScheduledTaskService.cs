using AutoMapper;
using Schdeuler.Repository;
using Schdeuler.Repository.Interfaces;
using Scheduler.Common.Enums;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;
using System;
using System.Collections.Generic;

namespace Scheduler.Service.Services
{
    /// <summary>
    /// Scheduled task service instance.
    /// </summary>
    public class ScheduledTaskService : IScheduledTaskService
    {
        private IScheduledTaskRepository repository;

        public ScheduledTaskService(IScheduledTaskRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ScheduledTaskDTO> GetTasksToDo()
        {
            IEnumerable<ScheduledTask> tasksToDo = repository.FindBy(t => t.PlanedExecutionDate < DateTime.UtcNow && t.ScheduledTaskStateId == (long)ScheduledTaskStates.Pending);
            return Mapper.Map<IEnumerable<ScheduledTaskDTO>>(tasksToDo);
        }

        public void ScheduleTask(ScheduledTaskDTO newTask)
        {
            throw new NotImplementedException();
        }

        public void RepeatTaskAfter(ScheduledTaskDTO scheduledTask, ScheduledTaskOffsetTypes offsetType, int n)
        {
            throw new NotImplementedException();
        }

        public void SetTasksAsSucceded(List<long> tasksToMarkAsSucceded)
        {
            throw new NotImplementedException();
        }

        public void SetTasksToErrorState(List<long> tasksToMarkAsErrorState)
        {
            throw new NotImplementedException();
        }
    }
}
