using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.TechGroup.Users.Interfaces
{
    public interface IUserInfrastructure
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<bool> CreateAsync(User user);
        public Task<bool> UpdateAsync(int id, User user);
        public Task<bool> DeleteAsync(int id);  
    }
}
