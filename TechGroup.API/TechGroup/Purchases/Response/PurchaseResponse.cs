namespace TechGroup.API.TechGroup.Purchases.Response
{
    public class PurchaseResponse
    { 
        public int id { get; set; }
        public int id_customer { get; set; }
        public string product_name { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        public DateOnly date_register { get; set; }
        public double interest { get; set; }
        public string status { get; set; }
    }
}

