using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;

namespace OrderManager.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddNewUser()
        {
            User user = new User() { UserName = "seed", FirstName = "Łukasz", LastName = "Jureczko", Email = "seed1@test.com" };
            _userRepository.AddUser(user);
        }
    }
}
