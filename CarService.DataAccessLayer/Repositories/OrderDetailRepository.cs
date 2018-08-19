using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.DataAccessLayer.Abstractions;
using CarService.DataAccessLayer.Data;
using CarService.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccessLayer.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>
    {
        private readonly CarServiceDbContext _context;

        public OrderDetailRepository(CarServiceDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<OrderDetail>> GetEntitiesAsync()
        {
            return await _context.OrderDetails
                .OrderBy(o => o.TimeFirst)
                .ToListAsync();
        }
    }
}
