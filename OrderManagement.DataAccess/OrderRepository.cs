using OrderManagement.DataAccess.Entities.Models;
using System.Collections.Generic;
using OrderManagement.DataAccess.Base;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.DataAccess
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(NorthwindContext context) : base(context) { }
        public OrderRepository() : base() { }

        public new Order GetBy(int id)
        {
            return context.Orders.Where(o => o.OrderId == id)
                .Include("Customer")
                .Include("OrderDetails")
                .Include("Products")
                .FirstOrDefault();
        }

        public new IEnumerable<Order> GetAll()
        {
            return context.Set<Order>()
                .Include("Customer")
                .Include("Employee")
                .Include("OrderDetails");
        }
    }
}