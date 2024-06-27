using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechGroup.Infrastructure.TechGroup.Purchases.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public required int Id_customer { get; set; }
        public required string Product_name { get; set; }
        public required double Price { get; set; }
        public required int Amount { get; set; }
        public required DateOnly Date_register { get; set; }
        public required double Interest { get; set; }
        public required string Status { get; set; }
    }
}
