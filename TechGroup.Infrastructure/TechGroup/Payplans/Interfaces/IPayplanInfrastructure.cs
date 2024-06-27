using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;

namespace TechGroup.Infrastructure.TechGroup.Payplans.Interfaces
{
    public interface IPayplanInfrastructure
    {
        public Task<List<Payplan>> GetAllAsync();
        public Task<Payplan> GetByIdAsync(int id);
        public Task<bool> CreateAsync(Payplan payplan);
        public Task<bool> UpdateAsync(int id, Payplan payplan);
        public Task<bool> DeleteAsync(int id);
    }
}
