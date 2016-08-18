using Autofac;
using Scheduler.Cleaner;
using Scheduler.Common.Enums;
using Scheduler.Common.Helpers;
using Scheduler.Common.Interfaces;
using Scheduler.Core.Types.Tasks;
using Scheduler.EmailSender;
using Scheduler.Helpers.DependencyInjection;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;
using Scheduler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Scheduler.Core
{
    /// <summary>
    /// Scheduler module class.
    /// </summary>
    public class SchedulerModule : IModule
    {
        /// <summary>
        /// Instance of <see cref="IScheduledTaskService"/> class.
        /// </summary>
        private IScheduledTaskService scheduledTaskService;

        private TimeSpan interval = new TimeSpan(0, Constants.SchedulerIntervalBetweenWorkInMinutes, 0);
        private Timer timer;

        private List<IModule> modules = new List<IModule>();

        public bool IsRunning { get; private set; } = false;

        /// <summary>
        /// Initialize scheduler.
        /// </summary>
        public void Initialize()
        {
            InitializeSubModules();

            Resolver.RegisterAutofacDependencyInjection();
        }

        /// <summary>
        /// Initialize a new instance of <see cref="SchedulerModule"/> class.
        /// </summary>
        public SchedulerModule()
        {
            Initialize();
            scheduledTaskService = Resolver.Container.Resolve<IScheduledTaskService>();
        }

        /// <summary>
        /// Run scheduler.
        /// </summary>
        public void Run()
        {
            if (IsRunning)
                return;
            IsRunning = true;

            RunSubModules();

            try
            {
                timer = new Timer
                {
                    AutoReset = true,
                    Interval = interval.TotalMilliseconds
                };
                timer.Elapsed += Work;
                timer.Start();
            }
            catch (Exception ex)
            {
                //TODO Add exception handling.
            }
        }

        /// <summary>
        /// Stop scheduler.
        /// </summary>
        public void Stop()
        {
            timer?.Stop();
            StopSubModules();
            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }

        private void InitializeSubModules()
        {
            modules?.Add(new EmailSenderModule());
            modules?.Add(new CleanerModule());

            modules?.ForEach(module => module.Initialize());
        }

        private void RunSubModules()
        {
            modules?.ForEach(module => module.Run());
        }

        private void StopSubModules()
        {
            modules?.ForEach(module => module.Stop());
        }

        /// <summary>
        /// Event invoked whatever scheduler should do its work.
        /// </summary>
        private void Work(object sender, ElapsedEventArgs e)
        {
            List<ScheduledTaskDTO> pendingTasks = scheduledTaskService.GetTasksToDo().ToList();
            List<long> tasksToMarkAsSucceded = new List<long>();
            List<long> tasksToMarkAsErrorState = new List<long>();
            foreach (ScheduledTaskDTO pendingTask in pendingTasks)
            {
                ScheduledTaskBase scheduledTask = ScheduledTaskFactory.GetTask(pendingTask.ScheduledTaskType);
                scheduledTask.Execute(pendingTask);

                if (pendingTask.ScheduledTaskState == ScheduledTaskStates.Succeded)
                    tasksToMarkAsSucceded.Add(pendingTask.ScheduledTaskId);
                else
                    tasksToMarkAsErrorState.Add(pendingTask.ScheduledTaskId);

            }
            scheduledTaskService.SetTasksAsSucceded(tasksToMarkAsSucceded);
            scheduledTaskService.SetTasksToErrorState(tasksToMarkAsErrorState);
        }
    }
}
