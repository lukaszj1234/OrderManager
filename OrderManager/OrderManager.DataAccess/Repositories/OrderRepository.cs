using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories
{
    public class OrderRepository
    {
        private OrderManagerDbContext _ctx;
        public OrderRepository(OrderManagerDbContext context)
        {
            _ctx = context;
        }
        public async Task<List<Order>> GetAllNewOrders()
        {
            return  await _ctx.Orders.Where(p => p.InProgress == true
            && p.Ended == false).ToListAsync();
        }
    }
}
