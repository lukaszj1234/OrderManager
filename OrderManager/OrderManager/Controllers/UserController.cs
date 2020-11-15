using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<IActionResult> AddNewUser(UserDetailsViewModel user)
        {
            IdentityResult result = new IdentityResult();
            if (checkIfObjectIsEmpty(user))
            {
                ModelState.Clear();
                return View(nameof(AddNewUser),new UserDetailsViewModel());
            }
            if (ModelState.IsValid && user.Id == null)
            {
                var validatePasswordResult = await _userRepository.ValidatePassword(user.Password);
                if (validatePasswordResult.Succeeded)
                {
                    result = await _userRepository.AddUser(
                        _mapper.Map<UserDetailsViewModel, User>(user), user.Password);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    ModelState.AddModelError("PasswordError",
                        "Hasło musi zawierać małe oraz duże litery, minimum 8 znaków " +
                        "oraz jeden znak niealfanumeryczny");
                }
            }
            else
            {
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");
                if (ModelState.IsValid && user.Id != null)
                {
                    result = await _userRepository.UpdateUser(_mapper.Map<UserDetailsViewModel, User>(user));
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }
        public IActionResult RedirectToChangePassword(UserViewModel user)
        {
           return RedirectToAction(nameof(ChangePassword), new ChangePasswordViewModel() {
               UserId = user.Id});
        }
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var validatePasswordResult = await _userRepository.ValidatePassword(model.Password);
                if (validatePasswordResult.Succeeded)
                {
                    var result = await _userRepository.UpdateUser(
                    model.UserId, model.Password);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    ModelState.AddModelError("PasswordError",
                        "Hasło musi zawierać małe oraz duże litery, minimum 8 znaków oraz jeden znak niealfanumeryczny");
                }
            }
            return View(model);
        }
        public async Task<ViewResult> EditUser(UserViewModel user)
        {
            var userFromDatabase = await _userRepository.GetUserByIdAsync(user.Id);
            UserDetailsViewModel userDetails = new UserDetailsViewModel();
            userDetails = _mapper.Map<User,UserDetailsViewModel>(userFromDatabase);
            return View("AddNewUser", userDetails);
        }
        private bool checkIfObjectIsEmpty(UserDetailsViewModel userModel)
        {
            return userModel.GetType().GetProperties()
                 .Where(p => p.GetValue(userModel) is string) 
                 .All(p => string.IsNullOrWhiteSpace((p.GetValue(userModel) as string)));
        }
    }
}
