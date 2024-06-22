using TechGroup.API.TechGroup.PurchasesProducts.Response;

namespace TechGroup.API.TechGroup.Products.Response;

public class ProductResponse
{
    public string Name { get; set; }
    public float Price { get; set; }
    public int Amount { get; set; }
    public DateOnly CreatedAt { get; set; }
    public List<PurchaseProductResponse> PurchaseProducts { get; set; }
}