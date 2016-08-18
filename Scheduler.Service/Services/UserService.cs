using System;
using Scheduler.Service.Interfaces;
using Scheduler.Service.Models;
using Schdeuler.Repository.Interfaces;
using Schdeuler.Repository;
using System.Linq;
using AutoMapper;

namespace Scheduler.Service.Services
{
    /// <summary>
    /// User service instance.
    /// </summary>
    public class UserService : IUserService
    {
        private IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public UserDTO GetUserById(long userId)
        {
            User user = repository.FindBy(u => u.Id == userId).FirstOrDefault();
            return Mapper.Map<UserDTO>(user);
        }
    }
}
