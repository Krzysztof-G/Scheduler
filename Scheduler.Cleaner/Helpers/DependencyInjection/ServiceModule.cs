using Autofac;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Services;

namespace Scheduler.Cleaner.Helpers.DependencyInjection
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ScheduledTaskService>().As<IScheduledTaskService>();
            builder.RegisterType<ScheduledTaskService>().As<IAnalysedDirectoryService>();
        }
    }
}
