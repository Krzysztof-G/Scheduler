using Scheduler.Common.Interfaces;
using Scheduler.EmailSender.Helpers.DependencyInjection;

namespace Scheduler.EmailSender
{
    public class EmailSenderModule : IModule
    {
        public bool IsRunning { get; private set; } = false;

        public void Initialize()
        {
            Resolver.RegisterAutofacDependencyInjection();
        }

        public void Run()
        {
            if (IsRunning)
                return;
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
