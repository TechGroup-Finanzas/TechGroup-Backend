

using TechGroup.Domain.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Models;

namespace TechGroup.Domain.TechGroup.Products.Services
{
    public class ProductDomain: IProductDomain
    {
        private readonly IProductInfrastructure _productInfrastructure;
        public ProductDomain(IProductInfrastructure productInfrastructure)
        {
            _productInfrastructure = productInfrastructure;
        }
        public async Task<bool> SaveAsync(Product product)
        {
            return await _productInfrastructure.CreateAsync(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _productInfrastructure.DeleteAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, Product product)
        {
            return await _productInfrastructure.UpdateAsync(id, product);
        }
    }
}
