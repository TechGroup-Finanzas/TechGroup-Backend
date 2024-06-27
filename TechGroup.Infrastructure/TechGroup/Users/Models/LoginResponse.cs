using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechGroup.Infrastructure.TechGroup.Users.Models
{
    public class LoginResponse
    {
        public required bool Success { get; set; }
        public required string Message { get; set; }
    }
}
