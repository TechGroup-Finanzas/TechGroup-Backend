using TechGroup.Infrastructure.TechGroup.Products.Models;

namespace TechGroup.Infrastructure.TechGroup.Products.Interfaces;

public interface IProductInfrastructure
{
    public Task<List<Product>> GetAllAsync();
    public Task<Product> GetByIdAsync(int id);
    public Task<bool> CreateAsync(Product product);
    public Task<bool> UpdateAsync(int id, Product product);
    public Task<bool> DeleteAsync(int id);
}