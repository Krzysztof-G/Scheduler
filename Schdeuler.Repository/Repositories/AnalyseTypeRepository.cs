using Schdeuler.Repository.Base;
using Schdeuler.Repository.Interfaces;

namespace Schdeuler.Repository.Repositories
{
    /// <summary>
    /// Analyse type repository.
    /// </summary>
    public class AnalyseTypeRepository : GenericRepository<SchedulerDBEntities, AnalyseType>, IAnalyseTypeRepository
    {
    }
}
