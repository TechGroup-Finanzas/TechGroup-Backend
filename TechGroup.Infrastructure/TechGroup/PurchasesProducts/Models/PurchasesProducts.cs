using TechGroup.Infrastructure.TechGroup.Products.Models;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.PurchasesProducts.Models;

public class PurchasesProducts
{
    public int PurchaseId { get; set; }
    public Purchase Purchase { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
}