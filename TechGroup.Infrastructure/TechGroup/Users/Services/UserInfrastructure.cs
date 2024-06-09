using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.TechGroup.Users.Services
{
    public class UserInfrastructure : IUserInfrastructure
    {
        public readonly TechGroupDbContext techGroupDbContext;

        public UserInfrastructure(TechGroupDbContext techGroupDbContext)
        {
            this.techGroupDbContext = techGroupDbContext;
        }

        public async Task<bool> CreateAsync(User user)
        {
            await techGroupDbContext.AddAsync(user);
            await techGroupDbContext.SaveChangesAsync();
            return true;
        
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userToDelete = await techGroupDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }
            techGroupDbContext.User.Remove(userToDelete);  
            await techGroupDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await techGroupDbContext.User.ToListAsync();
            return users;

        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await techGroupDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<bool> UpdateAsync(int id,User user)
        {
            var userToUpdate = await techGroupDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }
            userToUpdate.Name = user.Name;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.Dni = user.Dni;

            await techGroupDbContext.SaveChangesAsync();
            return true;
        }
    }
}
