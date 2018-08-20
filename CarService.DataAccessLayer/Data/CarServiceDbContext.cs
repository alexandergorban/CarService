using System;
using System.Collections.Generic;
using System.Text;
using CarService.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccessLayer.Data
{
    public class CarServiceDbContext : DbContext
    {
        public DbSet<OrderDetail> OrdersDetail { get; set; }
        public DbSet<UserDetail> UsersDetail { get; set; }
        public DbSet<CarType> CarTypes { get; set; }

        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
