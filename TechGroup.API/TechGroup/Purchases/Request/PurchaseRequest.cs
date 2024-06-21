namespace TechGroup.API.TechGroup.Purchases.Request;

public class PurchaseRequest
{
    public int UserId { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateRegister { get; set; }
    public decimal Interest { get; set; }
    public string Status { get; set; }
}