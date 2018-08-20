using System;
using System.Collections.Generic;
using System.Text;
using CarService.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccessLayer.Data
{
    public class CarServiceDbContext : DbContext
    {
        public DbSet<OrderDetail> ag_OrdersDetail { get; set; }
        public DbSet<UserDetail> ag_UsersDetail { get; set; }
        public DbSet<CarType> ag_CarTypes { get; set; }

        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
