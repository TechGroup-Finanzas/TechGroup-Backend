using TechGroup.Infrastructure.TechGroup.Purchases;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Domain.TechGroup.Purchases.Interfaces;

public interface IPurchaseDomain
{
    public Task<bool> CreatePurchaseAsync(Purchase purchase);
    public Task<bool> UpdatePurchaseAsync(int id, Purchase purchase);
    public Task<bool> DeletePurchaseAsync(int id);
    public Task<List<Purchase>> GetAllPurchasesAsync();
    public Task<Purchase> GetPurchaseByIdAsync(int id);
}