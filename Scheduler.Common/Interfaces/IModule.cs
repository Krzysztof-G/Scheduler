using System;

namespace Scheduler.Common.Interfaces
{
    /// <summary>
    /// Module interface.
    /// </summary>
    public interface IModule : IDisposable
    {
        void Initialize();
        void Run();
        void Stop();
        bool IsRunning { get; }
    }
}
