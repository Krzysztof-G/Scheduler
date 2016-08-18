using Scheduler.Cleaner.Helpers.DependencyInjection;
using Scheduler.Common.Interfaces;

namespace Scheduler.Cleaner
{
    /// <summary>
    /// Cleaner module.
    /// </summary>
    public class CleanerModule : IModule
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
