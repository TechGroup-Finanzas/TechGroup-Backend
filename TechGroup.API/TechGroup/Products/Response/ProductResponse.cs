using System.Security.Permissions;

namespace TechGroup.API.TechGroup.Products.Response;

public class ProductResponse
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public int amount { get; set; }
}