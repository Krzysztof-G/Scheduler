using Schdeuler.Repository.Base;
using Schdeuler.Repository.Interfaces;

namespace Schdeuler.Repository.Repositories
{
    /// <summary>
    /// Scheduled task repository.
    /// </summary>
    public class ScheduledTaskRepository : GenericRepository<SchedulerDBEntities, ScheduledTask>, IScheduledTaskRepository
    {
    }
}
