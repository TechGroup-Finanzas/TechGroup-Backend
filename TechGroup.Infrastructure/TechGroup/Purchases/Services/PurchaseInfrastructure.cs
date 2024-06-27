using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Services
{
    public class PurchaseInfrastructure : IPurchaseInfrastructure
    {
        private readonly TechGroupDbContext _context;

        public PurchaseInfrastructure(TechGroupDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Purchase purchase)
        {
            await _context.AddAsync(purchase);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
                throw new Exception("Purchase not found");
            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Purchase>> GetAllAsync()
        {
            var purchases = await _context.Purchase.ToListAsync();
            return purchases;
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            var purchases = await _context.Purchase.FirstOrDefaultAsync(x => x.Id == id);
            return purchases;
        }

        public async Task<bool> UpdateAsync(int id, Purchase purchase)
        {
            _context.Purchase.Update(purchase);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
