using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechGroup.Infrastructure.TechGroup.Payplans.Models
{
    public class Payplan
    {
        public int Id { get; set; }
        public int Id_customer { get; set; }
        public int Amount { get; set; }
        public int Monthlyrate { get; set; }
        public int Number_of_payments { get; set; }
        public int Grace_periods { get; set; }
        public string Grace_type { get; set; }
        public DateOnly Date_register { get; set; }
        public string Status { get; set; }
    }
}
