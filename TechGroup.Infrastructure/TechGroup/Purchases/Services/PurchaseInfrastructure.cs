using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Services;

public class PurchaseInfrastructure : IPurchaseInfrastructure
{
    private readonly TechGroupDbContext _techGroupDbContext;
    
    public PurchaseInfrastructure(TechGroupDbContext techGroupDbContext)
    {
        _techGroupDbContext = techGroupDbContext;
    }
    
    public async Task<bool> CreateAsync(Purchase purchase)
    {
        await _techGroupDbContext.AddAsync(purchase);
        await _techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Purchase>> GetAllAsync()
    {
        var purchases = await _techGroupDbContext.Purchase.ToListAsync();
        return purchases;
    }
    
    public async Task<Purchase> GetByIdAsync(int id)
    {
        var purchase = await _techGroupDbContext.Purchase.FindAsync(id);
        return purchase;
    }
    
    public async Task<bool> UpdateAsync(int id, Purchase purchase)
    {
        var purchaseToUpdate = await _techGroupDbContext.Purchase.FindAsync(id);
        if (purchaseToUpdate == null)
        {
            throw new Exception("Purchase not found");
        }
        
        purchaseToUpdate.UserId = purchase.UserId;
        purchaseToUpdate.Price = purchase.Price;
        purchaseToUpdate.Amount = purchase.Amount;
        purchaseToUpdate.DateRegister = purchase.DateRegister;
        purchaseToUpdate.Interest = purchase.Interest;
        purchaseToUpdate.Status = purchase.Status;

        _techGroupDbContext.Entry(purchaseToUpdate).State = EntityState.Modified;
        await _techGroupDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var purchase = await _techGroupDbContext.Purchase.FindAsync(id);
        if (purchase == null)
        {
            throw new Exception("Purchase not found");
        }
        _techGroupDbContext.Remove(purchase);
        await _techGroupDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Purchase>> GetByUserIdAsync(int userId)
    {
        return await _techGroupDbContext.Purchase
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Purchase>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate)
    {
        return await _techGroupDbContext.Purchase
            .Where(x => x.DateRegister >= startDate && x.DateRegister <= endDate)
            .ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _techGroupDbContext.Purchase.CountAsync();
    }
}