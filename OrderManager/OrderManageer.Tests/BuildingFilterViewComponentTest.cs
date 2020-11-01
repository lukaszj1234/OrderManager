using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using OrderManager.Components;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
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
            mock.Setup(m => m.GetAllBuildingsAsync()).ReturnsAsync((new Building[]
                {
                new Building() {Id = 1, Name = "B1"},
                new Building() {Id = 2, Name = "B2"},
                new Building() {Id = 3, Name = "B3"},
                }).AsEnumerable<Building>());
            BuildingFilterViewComponent component = new BuildingFilterViewComponent(mock.Object);
            //Act
            var returnElement =  (Building[])(await component.InvokeAsync() as ViewViewComponentResult).ViewData["BuildingList"];

            //Asseert
            Assert.Equal(3, returnElement.Count());
            Assert.Equal("B1", returnElement[0].Name);
            Assert.Equal("B2", returnElement[1].Name);
            Assert.Equal("B3", returnElement[2].Name);
        }
    }
}
