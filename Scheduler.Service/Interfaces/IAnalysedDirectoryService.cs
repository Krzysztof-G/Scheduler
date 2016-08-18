using Scheduler.Service.Models;

namespace Scheduler.Service.Interfaces
{
    /// <summary>
    /// Analused directory service interface.
    /// </summary>
    public interface IAnalysedDirectoryService
    {
        AnalysedDirectoryDTO GetAnalysedDirectoryById(long analysedDirectoryId);
    }
}
