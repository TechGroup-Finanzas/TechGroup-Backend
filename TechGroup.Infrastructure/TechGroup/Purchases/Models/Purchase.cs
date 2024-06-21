
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Models;

public class Purchase
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
    public double Amount { get; set; }
    public DateOnly DateRegister { get; set; }
    public double Interest { get; set; }
    public string Status { get; set; }
    
    public User User { get; set; }
    public ICollection<PurchasesProducts.Models.PurchasesProducts> PurchaseProducts { get; set; } // Relación muchos a muchos con Productos

    public Purchase()
    {
        PurchaseProducts = new HashSet<PurchasesProducts.Models.PurchasesProducts>();
    }
}
