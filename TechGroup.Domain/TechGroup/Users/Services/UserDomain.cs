using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Domain.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Domain.TechGroup.Users.Services
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserInfrastructure _userInfrastructure; 
        public UserDomain(IUserInfrastructure userInfrastructure)
        {
            _userInfrastructure = userInfrastructure;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userInfrastructure.DeleteAsync(id);
        }

        public async Task<bool> SaveAsync(User user)
        {
            return await _userInfrastructure.CreateAsync(user);
        }

        public async Task<bool> UpdateAsync(int id, User user)
        {
            return await _userInfrastructure.UpdateAsync(id, user);
        }
    }
}
