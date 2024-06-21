using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Interfaces;

public interface IPurchaseInfrastructure
{
    public Task<List<Purchase>> GetAllAsync();
    public Task<Purchase> GetByIdAsync(int id);
    public Task<bool> CreateAsync(Purchase purchase);
    public Task<bool> UpdateAsync(int id, Purchase purchase);
    public Task<bool> DeleteAsync(int id);
    public Task<List<Purchase>> GetByUserIdAsync(int userId);
    public Task<List<Purchase>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate);
    public Task<int> CountAsync();
}