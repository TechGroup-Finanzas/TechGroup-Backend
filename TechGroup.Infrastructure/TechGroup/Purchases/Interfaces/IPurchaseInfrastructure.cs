using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Interfaces
{
    public interface IPurchaseInfrastructure
    {
        Task<List<Purchase>> GetAllAsync();
        Task<Purchase> GetByIdAsync(int id);
        Task<bool> CreateAsync(Purchase purchase);
        Task<bool> UpdateAsync(int id, Purchase purchase);
        Task<bool> DeleteAsync(int id);

    }
}
