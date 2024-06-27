using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Payplans.Interfaces;
using TechGroup.Infrastructure.TechGroup.Payplans.Models;

namespace TechGroup.Infrastructure.TechGroup.Payplans.Services
{
    public class PayplanInfrastructure : IPayplanInfrastructure
    {
        public readonly TechGroupDbContext techGroupDbContext;

        public PayplanInfrastructure(TechGroupDbContext techGroupDbContext)
        {
            this.techGroupDbContext = techGroupDbContext;
        }

        public async Task<List<Payplan>> GetAllAsync()
        {
            var payplans = await techGroupDbContext.Payplan.ToListAsync();
            return payplans;
        }

        public async Task<Payplan> GetByIdAsync(int id)
        {
            var payplan = await techGroupDbContext.Payplan.FirstOrDefaultAsync(x => x.Id == id);
            return payplan;
        }

        public async Task<bool> CreateAsync(Payplan payplan)
        {
            await techGroupDbContext.AddAsync(payplan);
            await techGroupDbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> UpdateAsync(int id, Payplan payplan)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payplanToDelete = await techGroupDbContext.Payplan.FirstOrDefaultAsync(x => x.Id == id);
            if (payplanToDelete == null)
            {
                throw new Exception("Payplan not found");
            }
            techGroupDbContext.Payplan.Remove(payplanToDelete);
            await techGroupDbContext.SaveChangesAsync();
            return true;
        }
    }
}
