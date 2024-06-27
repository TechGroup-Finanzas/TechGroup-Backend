namespace TechGroup.API.TechGroup.Payplans.Request
{
    public class PayplanRequest
    {
        public int id_customer { get; set; }
        public int amount { get; set; }
        public int monthlyrate { get; set; }
        public int number_of_payments { get; set; }
        public int grace_periods { get; set; }
        public string grace_type { get; set; }
        public DateOnly date_register { get; set; }
        public string status { get; set; }
    }
}
