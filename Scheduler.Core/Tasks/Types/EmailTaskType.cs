using Autofac;
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
    /// Email task type class.
    /// </summary>
    public abstract class EmailTaskType : ScheduledTaskBase
    {
        /// <summary>
        /// The email service instance
        /// </summary>
        protected readonly IEmailService EmailService;

        /// <summary>
        /// The scheduled task service instance
        /// </summary>
        protected readonly IScheduledTaskService ScheduledTaskService;


        /// <summary>
        /// Initialize a new instance of <see cref="EmailTaskType"/> class.
        /// </summary>
        public EmailTaskType()
        {
            EmailService = Resolver.Container.Resolve<IEmailService>();
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
                EmailDTO email = new EmailDTO
                {
                    Type = scheduledTask.ScheduledTaskType.ToEmailType(),
                    RelatedObjectId = (long)scheduledTask.RelatedObjectId,
                };
                EmailFactory.GetEmail(scheduledTask.ScheduledTaskType.ToEmailType()).Send(email);
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
            ScheduledTaskService.RepeatTaskAfter(scheduledTask, ScheduledTaskOffsetTypes.AfterMinutes, 1);
        }
    }
}