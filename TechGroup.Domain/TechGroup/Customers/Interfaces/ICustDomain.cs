using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

namespace TechGroup.Domain.TechGroup.Customers.Interfaces
{
    public interface ICustDomain
    {
        public Task<bool> SaveAsync(Customer cust);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, Customer cust);
    }
}
