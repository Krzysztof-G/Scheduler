using Schdeuler.Repository.Base;
using Schdeuler.Repository.Interfaces;

namespace Schdeuler.Repository.Repositories
{
    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : GenericRepository<SchedulerDBEntities, User>, IUserRepository
    {
    }
}
