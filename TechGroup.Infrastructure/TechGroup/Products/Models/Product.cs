namespace TechGroup.Infrastructure.TechGroup.Products.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required float Price { get; set; }
    public required int Amount { get; set; }
    public DateOnly CreatedAt { get; set; }
}