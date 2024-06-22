using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechGroup.Infrastructure.TechGroup.Customers.Models
{
    public class Customer
    {
        public int Id {get;set;}
        public required int id_user {get;set;}
        public required string name { get; set; }
        public required string lastname { get; set; }
        public required string Dni { get; set; }
        public DateOnly birthdate{get;set;}
        public required string phone{get;set;}
        public required string email { get; set; }
        public required string rate_type{get;set;}
        public required string capitalization {get;set;}
        public required double rate{get;set;}
        public required string period{get;set;}
        public required double limit{get;set;}
        public required string status{get;set;}
        public required DateOnly payment_date { get; set; }
    }
}
