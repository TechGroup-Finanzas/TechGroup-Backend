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
            custToUpdate.User_id=cust.User_id;
            custToUpdate.Name = cust.Name;
            custToUpdate.Lastname = cust.Lastname;
            custToUpdate.Dni = cust.Dni;
            custToUpdate.Birthdate=cust.Birthdate;
            custToUpdate.Phone=cust.Phone;
            custToUpdate.Email = cust.Email;
            custToUpdate.Rate_type=cust.Rate_type;
            custToUpdate.Capitalization=cust.Capitalization;
            custToUpdate.Rate=cust.Rate;
            custToUpdate.Period=cust.Period;
            custToUpdate.Limit=cust.Limit;
            custToUpdate.Status=cust.Status;
            custToUpdate.Payment_date=cust.Payment_date;


            await techGroupDbContext.SaveChangesAsync();
            return true;
        }
    }
}
