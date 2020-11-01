using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManager.Controllers;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OrderManager.Tests
{
    public class AdminOrdersControllerTests
    {
        [Fact]
        public async void Can_Return_New_Orders()
        {
            //Arranege
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            mock.Setup(m => m.GetAllNewOrdersAsync()).ReturnsAsync((new Order[]
                {
                new Order() {Id = 1, Item = "I1", Building = new Building(){Name = "B1"} },
                new Order() {Id = 2, Item = "I2", Building = new Building(){Name = "B2"} },
                new Order() {Id = 3, Item = "I3", Building = new Building(){Name = "B3"} },
                }).AsEnumerable<Order>());
            var controller = new AdminOrdersController(mock.Object);
            //Act
            var returnElement = (List<OrderMainViewModel>)(await controller.NewOrders() as ViewResult).ViewData["Orders"];
            //Asseert
            Assert.Equal(3, returnElement.Count());
            Assert.Equal("I1", returnElement[0].OrderName);
            Assert.Equal("B1", returnElement[0].BuildingName);
            Assert.Equal("I2", returnElement[1].OrderName);
            Assert.Equal("B2", returnElement[1].BuildingName); 
            Assert.Equal("I3", returnElement[2].OrderName);
            Assert.Equal("B3", returnElement[2].BuildingName);
        }
    }
}
