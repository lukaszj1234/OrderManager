using Microsoft.AspNetCore.Identity;
using OrderManager.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IdentityResult> AddUser(User user, string password);
        Task<User> GetUserByIdAsync(string id);
        Task<IdentityResult> UpdateUser(User user);
        Task<IdentityResult> UpdateUser(User user, string password);
        Task<IdentityResult> UpdateUser(string userId, string password);
        Task<IdentityResult> ValidatePassword(string pass);
    }
}