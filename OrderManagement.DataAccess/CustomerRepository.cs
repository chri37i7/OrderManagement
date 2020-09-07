using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Base;
using OrderManagement.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DataAccess
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository(NorthwindContext context) : base(context) { }
        public CustomerRepository() : base() { }

        public new async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Set<Customer>().Include("Orders").ToListAsync();
        }
    }
}
