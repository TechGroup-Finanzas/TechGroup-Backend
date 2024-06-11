using TechGroup.Infrastructure.TechGroup.Products.Models;

namespace TechGroup.Domain.TechGroup.Products.Interfaces
{
    public interface IProductDomain
    {
        public Task<bool> SaveAsync(Product product);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, Product product);
    }
}