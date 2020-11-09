using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Components
{
    public class BuildingFilterViewComponent : ViewComponent
    {
        private IBuildingRepository _buildingRepository;
        private IUserRepository _userRepository;

        public BuildingFilterViewComponent(IBuildingRepository buildingRepository,
            IUserRepository userRepository)
        {
            _buildingRepository = buildingRepository;
            _userRepository = userRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.BuildingList = await _buildingRepository.GetAllBuildingsAsync();
            List<UserViewModel> userList = new List<UserViewModel>();
            var users = await _userRepository.GetAllUsersAsync();
            foreach (var item in users)
            {
                userList.Add(new UserViewModel() { Id = item.Id, FullName = item.FirstName + " " + item.LastName });
            }
            ViewBag.UserList = userList;
            return View();
        }
    }
}
