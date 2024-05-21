using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Domain.TechGroup.Users.Interfaces
{
    public interface IUserDomain
    {
        public Task<bool> SaveAsync(User user);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, User user);
    }
}
