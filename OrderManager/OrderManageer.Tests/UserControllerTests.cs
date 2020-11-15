using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManager.Configuration;
using OrderManager.Controllers;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using OrderManager.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OrderManager.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async void Index_Can_Return_Users()
        {
            //Arrange
            Mock <IUserRepository> mockRepository = new Mock<IUserRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            mockRepository.Setup(m => m.GetAllUsersAsync()).ReturnsAsync((new List<User> {
                new User() {Id = "1", FirstName = "F1", LastName = "L1" },
                new User() {Id = "2", FirstName = "F2", LastName = "L2" },
                new User() {Id = "3", FirstName = "F3", LastName = "L3" }
            }).AsEnumerable<User>());
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = (List<UserViewModel>)(await controller.Index() as ViewResult).Model;
            //Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("F1 L1", result[0].FullName);
            Assert.Equal("F2 L2", result[1].FullName);
            Assert.Equal("F3 L3", result[2].FullName);
        }

        [Fact]
        public async void AddNewUser_Can_Return_Empty_View()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.AddNewUser(new UserDetailsViewModel()) as ViewResult;
            //Assert
            Assert.Equal(0, result.ViewData.ModelState.ErrorCount);
            Assert.Equal("AddNewUser", result.ViewName);
        }

        [Fact]
        public async void AddNewUser_Can_Validate_Password()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var identityResult = IdentityResult.Failed(new IdentityError());
            mockRepository.Setup(m => m.ValidatePassword("1234")).ReturnsAsync(identityResult);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.AddNewUser(new UserDetailsViewModel() {Password = "1234" }) as ViewResult;
            //Assert
            Assert.Equal(1, result.ViewData.ModelState.ErrorCount);
            Assert.Equal("PasswordError", result.ViewData.ModelState.Keys.First());
        }

        [Fact]
        public async void AddNewUser_Can_Add_New_User()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var identityResult = IdentityResult.Success;
            mockRepository.Setup(m => m.ValidatePassword("Password15@")).ReturnsAsync(identityResult);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.AddNewUser(new UserDetailsViewModel() { Password = "Password15@" });
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepository.Verify(mock => mock.ValidatePassword("Password15@"), Times.Once());
        }

        [Fact]
        public async void AddNewUser_Can_Update_User()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.AddNewUser(new UserDetailsViewModel() {Id = "1"});
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async void ChangePassword_Can_Change_Password()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var identityResult = IdentityResult.Success;
            mockRepository.Setup(m => m.ValidatePassword("Password15@")).ReturnsAsync(identityResult);
            ChangePasswordViewModel passwordViewModel = new ChangePasswordViewModel() { UserId = "1", Password = "Password15@" };
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.ChangePassword(passwordViewModel);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepository.Verify(mock => mock.UpdateUser(passwordViewModel.UserId, passwordViewModel.Password), Times.Once());
        }

        [Fact]
        public async void EditUser_Can_Edit_User()
        {
            //Arrange
            Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            UserViewModel user = new UserViewModel() { Id = "1" };
            mockRepository.Setup(m => m.GetUserByIdAsync("1")).ReturnsAsync(new User()
            { FirstName = "F1", LastName = "L1", Id = "1" });
            var controller = new UserController(mockRepository.Object, new Mapper(mappingConfig));
            //Act
            var result = await controller.EditUser(user);
            var userResult = (UserDetailsViewModel)result.Model;
            //Assert
            Assert.Equal("AddNewUser", result.ViewName);
            Assert.Equal("F1", userResult.FirstName);
            Assert.Equal("L1", userResult.LastName);
        }
    }
}
