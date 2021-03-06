﻿using OrderManager.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllNewOrdersAsync();
        Task<IEnumerable<Order>> GetAllInProgressOrdersAsync();
        Task<IEnumerable<Order>> GetAllEndedOrdersAsync();
    }
}