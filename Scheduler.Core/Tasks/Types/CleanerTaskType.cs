using Autofac;
using Scheduler.Cleaner.Model;
using Scheduler.Cleaner.Tasks;
using Scheduler.Common.Enums;
using Scheduler.Core.Types.Tasks;
using Scheduler.EmailScheduler.Tasks;
using Scheduler.EmailSender.Interfaces;
using Scheduler.EmailSender.Models;
using Scheduler.Helpers.DependencyInjection;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;
using System;

namespace Scheduler.Core.Tasks.Types
{
    /// <summary>
    /// Cleaner task type class.
    /// </summary>
    public abstract class CleanerTaskType : ScheduledTaskBase
    {
        /// <summary>
        /// The analysed directory service instance
        /// </summary>
        protected readonly IAnalysedDirectoryService AnalysedDirectoryService;

        /// <summary>
        /// The scheduled task service instance
        /// </summary>
        protected readonly IScheduledTaskService ScheduledTaskService;


        /// <summary>
        /// Initialize a new instance of <see cref="EmailTaskType"/> class.
        /// </summary>
        public CleanerTaskType()
        {
            AnalysedDirectoryService = Resolver.Container.Resolve<IAnalysedDirectoryService>();
            ScheduledTaskService = Resolver.Container.Resolve<IScheduledTaskService>();
            State = ScheduledTaskStates.Pending;
        }

        /// <summary>
        /// Execute scheduled task.
        /// </summary>
        /// <param name="scheduledTask">Task to execute</param>
        /// <returns>True - task executed successful, False - error occurred during task executing.</returns>
        protected override void Executing(ScheduledTaskDTO scheduledTask)
        {
            try
            {
                State = ScheduledTaskStates.Executing;
                AnalyzeDTO email = new AnalyzeDTO(scheduledTask.ScheduledTaskType.ToAnalyseTypes(), (long)scheduledTask.RelatedObjectId);
                CleanerFactory.GetTask(scheduledTask.ScheduledTaskType.ToAnalyseTypes()).Analyze(email);
                State = ScheduledTaskStates.Succeded;
            }
            catch (Exception ex)
            {
                State = ScheduledTaskStates.Error;
                //TODO Add exception handling.
            }
        }

        /// <summary>
        /// Invoked when during task executing curated error.
        /// </summary>
        /// <param name="scheduledTask">Scheduled task.</param>
        protected override void OnError(ScheduledTaskDTO scheduledTask)
        {
            ScheduledTaskService.RepeatTaskAfter(scheduledTask, ScheduledTaskOffsetTypes.AfterMinutes, 15);
        }
    }
}