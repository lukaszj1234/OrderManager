using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using OrderManager.Components;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderManageer.Tests
{
    public class BuildingFilterViewComponentTest
    {
        [Fact]
        public async void Can_Return_Buildings()
        {
            //Arranege
            Mock<IBuildingRepository> mock = new Mock<IBuildingRepository>();
            Mock<IUserRepository> mockUser = new Mock<IUserRepository>();
            mock.Setup(m => m.GetAllBuildingsAsync()).ReturnsAsync((new Building[]
                {
                new Building() {Id = 1, Name = "B1"},
                new Building() {Id = 2, Name = "B2"},
                new Building() {Id = 3, Name = "B3"},
                }).AsEnumerable<Building>());
            BuildingFilterViewComponent component = new BuildingFilterViewComponent(mock.Object, mockUser.Object);
            //Act
            var returnElement =  (Building[])(await component.InvokeAsync() as ViewViewComponentResult).ViewData["BuildingList"];

            //Asseert
            Assert.Equal(3, returnElement.Count());
            Assert.Equal("B1", returnElement[0].Name);
            Assert.Equal("B2", returnElement[1].Name);
            Assert.Equal("B3", returnElement[2].Name);
        }

        [Fact]
        public async void Can_Return_Users()
        {
            //Arranege
            Mock<IBuildingRepository> mock = new Mock<IBuildingRepository>();
            Mock<IUserRepository> mockUser = new Mock<IUserRepository>();
            mockUser.Setup(m => m.GetAllUsersAsync()).ReturnsAsync((new User[]
                {
                new User() {Id = "1", FirstName = "F1", LastName="L1"},
                new User() {Id = "2", FirstName = "F2", LastName="L2"},
                new User() {Id = "3", FirstName = "F3", LastName="L3"},
                }).AsEnumerable<User>());
            BuildingFilterViewComponent component = new BuildingFilterViewComponent(mock.Object, mockUser.Object);
            //Act
            var returnElement = (List<UserViewModel>)(await component.InvokeAsync() as ViewViewComponentResult).ViewData["UserList"];

            //Asseert
            Assert.Equal(3, returnElement.Count());
            Assert.Equal("F1 L1", returnElement[0].FullName);
            Assert.Equal("F2 L2", returnElement[1].FullName);
            Assert.Equal("F3 L3", returnElement[2].FullName);
        }
    }
}
