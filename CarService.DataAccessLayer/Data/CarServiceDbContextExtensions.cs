using System;
using System.Collections.Generic;
using System.Text;
using CarService.DataAccessLayer.Entities;

namespace CarService.DataAccessLayer.Data
{
    public static class CarServiceDbContextExtensions
    {
        public static void EnsureSeedDataForContext(this CarServiceDbContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously

            context.OrdersDetail.RemoveRange(context.OrdersDetail);
            context.UsersDetail.RemoveRange(context.UsersDetail);
            context.CarTypes.RemoveRange(context.CarTypes);
            context.SaveChanges();

            // init seed data
            var ordersDetail = new List<OrderDetail>()
            {
                new OrderDetail()
                {
                    DataFirst = DateTime.Now,
                    DataSecond = DateTime.Now,
                    UserDetail = new UserDetail()
                    {
                        FirstName = "Jins",
                        EMail = "jinstest@test.com"
                    }
                },
                new OrderDetail()
                {
                    DataFirst = DateTime.Now,
                    DataSecond = DateTime.Now,
                    UserDetail = new UserDetail()
                    {
                        FirstName = "Mike",
                        EMail = "miketest@test.com"
                    }
                }
            };

            var carTypes = new List<CarType>()
            {
                new CarType()
                {
                    ModelId = 1,
                    Model = "Toyota"
                },
                new CarType()
                {
                    ModelId = 2,
                    Model = "Hyundai"
                },
                new CarType()
                {
                    ModelId = 3,
                    Model = "Reno"
                },
                new CarType()
                {
                    ModelId = 4,
                    Model = "Audi"
                }
            };

            context.OrdersDetail.AddRange(ordersDetail);
            context.CarTypes.AddRange(carTypes);
            context.SaveChanges();
        }
    }
}
