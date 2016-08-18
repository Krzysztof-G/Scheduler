using System;
using Scheduler.Common.Enums;
using Scheduler.Service.Models;
using Scheduler.Service.Interfaces;
using Scheduler.Helpers.DependencyInjection;
using Autofac;
using Scheduler.Common;

namespace Scheduler.Core.Types.Tasks
{
    public abstract class ScheduledTaskBase
    {

        /// <summary>
        /// Scheduled task service instance.
        /// </summary>
        protected IScheduledTaskService scheduledTaskService;


        /// <summary>
        /// Initialize instance of <see cref="ScheduledTaskBase"/> class.
        /// </summary>
        public ScheduledTaskBase()
        {
            scheduledTaskService = Resolver.Container.Resolve<IScheduledTaskService>();
        }

        /// <summary>
        /// State of Task
        /// </summary>
        public ScheduledTaskStates State { get; protected set; }

        /// <summary>
        /// Type of task.
        /// </summary>
        public abstract ScheduledTaskTypes Type { get; }

        /// <summary>
        /// Prepare task to scheduling..
        /// </summary>
        public abstract void ScheduleTask(long? relatedObjectId);

        /// <summary>
        /// Schedule task.
        /// </summary>
        /// <param name="relatedObjectId">Id of related to task object.</param>
        /// <param name="plannedTime">Task execution time.</param>
        protected void Scheduling(long? relatedObjectId, DateTime plannedTime)
        {
            ScheduledTaskDTO newTask = new ScheduledTaskDTO()
            {
                CreationDate = DateTime.Now,
                PlannedExecutionDate = plannedTime,
                RelatedObjectId = relatedObjectId,
                ScheduledTaskState = ScheduledTaskStates.Pending,
                ScheduledTaskType = Type,
            };

            scheduledTaskService.ScheduleTask(newTask);
        }

        /// <summary>
        /// Execute scheduled task.
        /// </summary>
        public void Execute(ScheduledTaskDTO scheduledTask)
        {
            BeforeExecute(scheduledTask);
            try
            {
                Executing(scheduledTask);
            }
            catch (Exception ex)
            {
                //TODO Add exception handling.
            }
            AfterExecute(scheduledTask);
        }

        /// <summary>
        /// Executing scheduled task.
        /// </summary>
        /// <param name="scheduledTask">Task to execute</param>
        protected abstract void Executing(ScheduledTaskDTO scheduledTask);

        /// <summary>
        /// Execute scheduled task.
        /// </summary>
        protected virtual void BeforeExecute(ScheduledTaskDTO scheduledTask)
        {
            State = ScheduledTaskStates.Executing;
            scheduledTask.ScheduledTaskState = State;
        }

        /// <summary>
        /// Execute scheduled task.
        /// <param name="scheduledTask">Task to analyze</param>
        /// </summary>
        protected virtual void AfterExecute(ScheduledTaskDTO scheduledTask)
        {
            State = scheduledTask.ScheduledTaskState;
            if (State == ScheduledTaskStates.Succeded)
            {
                ScheduleNewTask(scheduledTask);
            }
            else
            {
                State = ScheduledTaskStates.Error;
                OnError(scheduledTask);
            }
        }

        /// <summary>
        /// Invoked when during task executing ocurated error.
        /// </summary>
        /// <param name="scheduledTask"></param>
        protected virtual void OnError(ScheduledTaskDTO scheduledTask)
        {
            scheduledTaskService.RepeatTaskAfter(scheduledTask, ScheduledTaskOffsetTypes.AfterMinutes, 1);
        }

        /// <summary>
        /// Curated when task execute complete.
        /// </summary>
        /// <param name="scheduledTask">Executed task.</param>
        protected virtual void ScheduleNewTask(ScheduledTaskDTO scheduledTask)
        {
        }
    }
}
