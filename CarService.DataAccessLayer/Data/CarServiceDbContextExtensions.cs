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
                    Id = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    DataFirst = DateTime.Now,
                    DataSecond = DateTime.Now,
                    UserDetail = new UserDetail()
                    {
                        Id = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                        FirstName = "Jins",
                        EMail = "jinstest@test.com"
                    }
                },
                new OrderDetail()
                {
                    Id = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    DataFirst = DateTime.Now,
                    DataSecond = DateTime.Now,
                    UserDetail = new UserDetail()
                    {
                        Id = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                        FirstName = "Mike",
                        EMail = "miketest@test.com"
                    }
                }
            };

            var carTypes = new List<CarType>()
            {
                new CarType()
                {
                    Id = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                    ModelId = 1,
                    Model = "Toyota"
                },
                new CarType()
                {
                    Id = new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                    ModelId = 2,
                    Model = "Hyundai"
                },
                new CarType()
                {
                    Id = new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                    ModelId = 3,
                    Model = "Reno"
                },
                new CarType()
                {
                    Id = new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
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
