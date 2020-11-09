using OrderManager.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        void AddUser(User user);
    }
}