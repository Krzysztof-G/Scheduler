using Scheduler.Service.Models;

namespace Scheduler.Service.Interfaces
{
    /// <summary>
    /// User service interface.
    /// </summary>
    public interface IUserService
    {
        UserDTO GetUserById(long userId);
    }
}
