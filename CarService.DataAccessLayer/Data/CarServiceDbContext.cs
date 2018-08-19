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

        public CarServiceDbContext()
        {
            // todo
            if (Database.EnsureCreated())
            {
                this.EnsureSeedDataForContext();
            }
        }

        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options)
            : base(options)
        {
            // todo
            if (Database.EnsureCreated())
            {
                this.EnsureSeedDataForContext();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=CarServiceDB;integrated security=yes;connectretrycount=0;AttachDBFileName=c:\users\alexander\carservicedb.mdf");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
