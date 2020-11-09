using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;

namespace OrderManager.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ViewResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            List<UserViewModel> userList = new List<UserViewModel>();
            foreach (var item in users)
            {
                userList.Add(new UserViewModel() { Id = item.Id, FullName = item.FirstName + " " + item.LastName });
            }
            return View(userList);
        }

        public void AddNewUser()
        {
            User user = new User() { UserName = "seed", FirstName = "Łukasz", LastName = "Jureczko", Email = "seed1@test.com" };
            _userRepository.AddUser(user);
        }
    }
}
