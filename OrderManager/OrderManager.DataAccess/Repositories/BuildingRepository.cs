using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Models;
using OrderManager.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DataAccess.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private OrderManagerDbContext _ctx;
        public BuildingRepository(OrderManagerDbContext context)
        {
            _ctx = context;
        }
        public async Task<IEnumerable<Building>> GetAllBuildingsAsync()
        {
            return await _ctx.Buildings.ToListAsync();
        }
        public async Task<Building> GetByIdAsync(int id)
        {
            return await _ctx.Buildings.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
