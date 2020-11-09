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
        public async void AddUser(User user)
        {
            string pass = "Seed1234@";
            IdentityResult result = _userManager.CreateAsync(user,pass ).Result;
            result = null;
        }
    }
}
