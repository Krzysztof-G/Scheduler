using Autofac;
using Scheduler.EmailSender.Interfaces;
using Scheduler.EmailSender.Services;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Services;

namespace Scheduler.EmailSender.Helpers.DependencyInjection
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>().As<IEmailService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ScheduledTaskService>().As<IScheduledTaskService>();
        }
    }
}
