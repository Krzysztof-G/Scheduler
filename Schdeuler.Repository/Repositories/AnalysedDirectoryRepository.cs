using Schdeuler.Repository.Base;
using Schdeuler.Repository.Interfaces;

namespace Schdeuler.Repository.Repositories
{
    /// <summary>
    /// Analysed directory repository.
    /// </summary>
    public class AnalysedDirectoryRepository : GenericRepository<SchedulerDBEntities, AnalysedDirectory>, IAnalysedDirectoryRepository
    {
    }
}
