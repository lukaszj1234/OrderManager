using OrderManager.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories.Interfaces
{
    public interface IBuildingRepository
    {
        Task<IEnumerable<Building>> GetAllBuildingsAsync();
        Task<Building> GetByIdAsync(int id);
    }
}