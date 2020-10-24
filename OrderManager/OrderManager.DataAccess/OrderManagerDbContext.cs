using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.DataAccess
{
    public class OrderManagerDbContext : DbContext
    {
        public OrderManagerDbContext(DbContextOptions<OrderManagerDbContext>
           options) : base(options) { }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
