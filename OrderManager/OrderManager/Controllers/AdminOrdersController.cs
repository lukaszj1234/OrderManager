using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;

namespace OrderManager.Controllers
{
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
            var orderList = await _orderRepository.GetAllNewOrders();
            List<OrderMainViewModel> returnList = new List<OrderMainViewModel>();
            foreach (var item in orderList)
            {
                var orderItem = new OrderMainViewModel();
                orderItem.BuildingName = item.Building.Name;
                orderItem.OrderName = item.Item;
                returnList.Add(orderItem);
                ViewBag.Orders = returnList;
            }
            return View();
        }
    }
}
