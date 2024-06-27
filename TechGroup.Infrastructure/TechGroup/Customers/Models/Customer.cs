using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.Infrastructure.TechGroup.Customers.Models
{
    public class Customer
    {
        public int Id {get;set;}
        public required int User_id {get;set;}
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public required string Dni { get; set; }
        public DateOnly Birthdate{get;set;}
        public required string Phone{get;set;}
        public required string Email { get; set; }
        public required string Rate_type{get;set;}
        public required string Capitalization {get;set;}
        public required double Rate{get;set;}
        public required string Period{get;set;}
        public required double Limit{get;set;}
        public required string Status{get;set;}
        public required int Payment_date { get; set; }
    }
}
