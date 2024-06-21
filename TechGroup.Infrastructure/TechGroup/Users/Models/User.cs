﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Purchases.Models;

namespace TechGroup.Infrastructure.TechGroup.Users.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Dni { get; set; }
        public DateOnly CreatedAt { get; set; }
        
        public ICollection<Purchase> Purchases { get; set; }
    }
}
