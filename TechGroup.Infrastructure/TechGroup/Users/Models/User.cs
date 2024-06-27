using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public required DateOnly Birthday { get; set; }
        public DateOnly CreatedAt { get; set; }
        public required string Phone { get; set;  }
        public required string Photo { get; set;  }
        public required double Mora { get; set;  }
    }
}
