using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

namespace TechGroup.Infrastructure.TechGroup.Customers.Interfaces
{
    public interface ICustInfrastructure
    {
        public Task<List<Customer>> GetAllAsync();
        public Task<Customer> GetByIdAsync(int id);
        public Task<bool> CreateAsync(Customer cust);
        public Task<bool> UpdateAsync(int id, Customer cust);
        public Task<bool> DeleteAsync(int id);  
    }
}
