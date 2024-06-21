namespace TechGroup.Infrastructure.TechGroup.Products.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required float Price { get; set; }
    public required int Amount { get; set; }
    public DateOnly CreatedAt { get; set; }
    public ICollection<PurchasesProducts.Models.PurchasesProducts> PurchaseProducts { get; set; } // Relación muchos a muchos con Purchase
    public Product()
    {
        PurchaseProducts = new HashSet<PurchasesProducts.Models.PurchasesProducts>();
    }
}