using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<User> _userManager;
        private OrderManagerDbContext _ctx;

        public UserRepository(UserManager<User> userManager,
            OrderManagerDbContext context)
        {
            _userManager = userManager;
            _ctx = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
        public async Task<IdentityResult> AddUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        public async Task<IdentityResult> UpdateUser(User user)
        {
            var user1 = await _userManager.FindByIdAsync(user.Id);
            user1.FirstName = user.FirstName;
            user1.Email = user.Email;
            user1.LastName = user.LastName;
            var result = await _userManager.UpdateAsync(user1);
            return result;
        }
        public async Task<IdentityResult> UpdateUser(User user, string password)
        {
            await UpdateUser(user);
            var user1 = await _userManager.FindByIdAsync(user.Id);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            return result;
        }
        public async Task<IdentityResult> UpdateUser(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            return result;
        }
        public async Task<IdentityResult> ValidatePassword(string pass)
        {
            var passwordValidator = new PasswordValidator<User>();
            return await passwordValidator.ValidateAsync(_userManager, null, pass);
        }
    }
}
