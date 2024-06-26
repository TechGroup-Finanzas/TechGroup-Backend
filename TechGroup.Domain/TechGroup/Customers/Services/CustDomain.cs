using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Domain.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

namespace TechGroup.Domain.TechGroup.Customers.Services
{
    public class CustDomain : ICustDomain
    {
        private readonly ICustInfrastructure _custInfrastructure; 
        public CustDomain(ICustInfrastructure custInfrastructure)
        {
            _custInfrastructure = custInfrastructure;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _custInfrastructure.DeleteAsync(id);
        }

        public async Task<bool> SaveAsync(Customer cust)
        {
            return await _custInfrastructure.CreateAsync(cust);
        }

        public async Task<bool> UpdateAsync(int id, Customer cust)
        {
            return await _custInfrastructure.UpdateAsync(id, cust);
        }
    }
}
