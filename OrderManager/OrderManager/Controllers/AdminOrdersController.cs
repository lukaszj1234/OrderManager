using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;

namespace OrderManager.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminOrdersController : Controller
    {
        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public AdminOrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> NewOrders()
        {
            var orderList = await _orderRepository.GetAllNewOrdersAsync();
            ViewBag.Orders = GetOrderList(orderList);
            return View();
        }
        public async Task<IActionResult> OrdersInProgress()
        {
            var orderList = await _orderRepository.GetAllInProgressOrdersAsync();
            ViewBag.Orders = GetOrderList(orderList);
            return View();
        }
        public async Task<IActionResult> EndedOrders()
        {
            var orderList = await _orderRepository.GetAllEndedOrdersAsync();
            ViewBag.Orders = GetOrderList(orderList);
            return View();
        }
        private List<OrderMainViewModel> GetOrderList(IEnumerable<Order> orders)
        {
            var returnList = new List<OrderMainViewModel>();
            foreach (var item in orders)
            {
                var orderItem = new OrderMainViewModel();
                orderItem.BuildingName = item.Building.Name;
                orderItem.OrderName = item.Item;
                returnList.Add(orderItem);
            }
            return returnList;
        }
    }
}
