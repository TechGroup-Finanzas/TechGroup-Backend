using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using TechGroup.Infrastructure.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Models;

namespace TechGroup.Infrastructure.TechGroup.Products.Services;

public class ProductInfrastructure : IProductInfrastructure
{
    public readonly TechGroupDbContext techGroupDbContext;
    
    public ProductInfrastructure(TechGroupDbContext techGroupDbContext)
    {
        this.techGroupDbContext = techGroupDbContext;
    }
    
    public async Task<bool> CreateAsync(Product product)
    {
        await techGroupDbContext.AddAsync(product);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var productToDelete = await techGroupDbContext.Product.FirstOrDefaultAsync(x => x.Id == id);
        if (productToDelete == null)
        {
            throw new Exception("Product not found");
        }
        techGroupDbContext.Product.Remove(productToDelete);
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<List<Product>> GetAllAsync()
    {
        var products = await techGroupDbContext.Product.ToListAsync();
        return products;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await techGroupDbContext.Product.FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }
    
    public async Task<bool> UpdateAsync(int id, Product product)
    {
        var productToUpdate = await techGroupDbContext.Product.FirstOrDefaultAsync(x => x.Id == id);
        if (productToUpdate == null)
        {
            throw new Exception("Product not found");
        }
        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Amount = product.Amount;
        await techGroupDbContext.SaveChangesAsync();
        return true;
    }
}