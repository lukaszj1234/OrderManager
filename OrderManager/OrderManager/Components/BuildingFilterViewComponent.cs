using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace OrderManager.Components
{
    public class BuildingFilterViewComponent : ViewComponent
    {
        private IBuildingRepository _buildingRepository;

        public BuildingFilterViewComponent(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.BuildingList = await _buildingRepository.GetAllBuildingsAsync();
            return View();
        }
    }
}
