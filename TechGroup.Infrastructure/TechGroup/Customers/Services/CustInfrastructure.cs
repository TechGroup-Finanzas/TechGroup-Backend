using Microsoft.EntityFrameworkCore;
using TechGroup.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechGroup.Infrastructure.TechGroup.Customers.Interfaces;
using TechGroup.Infrastructure.TechGroup.Customers.Models;

namespace TechGroup.Infrastructure.TechGroup.Customers.Services
{
    public class CustInfrastructure : ICustInfrastructure
    {
        public readonly TechGroupDbContext techGroupDbContext;

        public CustInfrastructure(TechGroupDbContext techGroupDbContext)
        {
            this.techGroupDbContext = techGroupDbContext;
        }

        public async Task<bool> CreateAsync(Customer cust)
        {
            await techGroupDbContext.AddAsync(cust);
            await techGroupDbContext.SaveChangesAsync();
            return true;
        
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var custToDelete = await techGroupDbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);
            if (custToDelete == null)
            {
                throw new Exception("Customer not found");
            }
            techGroupDbContext.Customer.Remove(custToDelete);  
            await techGroupDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await techGroupDbContext.Customer.ToListAsync();
            return customers;

        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var cust = await techGroupDbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);
            return cust;
        }

        public async Task<bool> UpdateAsync(int id,Customer cust)
        {
            var custToUpdate = await techGroupDbContext.Customer.FirstOrDefaultAsync(x => x.Id == id);
            if (custToUpdate == null)
            {
                throw new Exception("Customer not found");
            }
            custToUpdate.id_user=cust.id_user;
            custToUpdate.name = cust.name;
            custToUpdate.lastname = cust.lastname;
            custToUpdate.Dni = cust.Dni;
            custToUpdate.birthdate=cust.birthdate;
            custToUpdate.phone=cust.phone;
            custToUpdate.email = cust.email;
            custToUpdate.rate_type=cust.rate_type;
            custToUpdate.capitalization=cust.capitalization;
            custToUpdate.rate=cust.rate;
            custToUpdate.period=cust.period;
            custToUpdate.limit=cust.limit;
            custToUpdate.status=cust.status;
            custToUpdate.payment_date=cust.payment_date;



            await techGroupDbContext.SaveChangesAsync();
            return true;
        }
    }
}
