using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private OrderManagerDbContext _ctx;
        public OrderRepository(OrderManagerDbContext context)
        {
            _ctx = context;
        }
        public async Task<IEnumerable<Order>> GetAllNewOrdersAsync()
        {
           return await _ctx.Orders.Where(p => p.InProgress == false
           && p.Ended == false)
              .Include(p => p.Building)
              .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllInProgressOrdersAsync()
        {
          return await _ctx.Orders.Where(p => p.InProgress == true
          && p.Ended == false)
             .Include(p => p.Building)
             .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllEndedOrdersAsync()
        {
          return await _ctx.Orders.Where(p => p.InProgress == true
          && p.Ended == true)
             .Include(p => p.Building)
             .ToListAsync();
        }
    }
}
