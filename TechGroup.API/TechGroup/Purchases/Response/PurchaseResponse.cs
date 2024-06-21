using TechGroup.API.TechGroup.PurchasesProducts.Response;
using TechGroup.API.TechGroup.Users.Response;

namespace TechGroup.API.TechGroup.Purchases.Response;

public class PurchaseResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateRegister { get; set; }
    public decimal Interest { get; set; }
    public string Status { get; set; }
    public UserResponse User { get; set; }
    public List<PurchaseProductResponse> PurchaseProducts { get; set; }
}