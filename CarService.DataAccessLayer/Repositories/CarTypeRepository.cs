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
    public class CarTypeRepository : BaseRepository<CarType>
    {
        private readonly CarServiceDbContext _context;

        public CarTypeRepository(CarServiceDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<IEnumerable<CarType>> GetEntitiesAsync()
        {
            return await _context.CarTypes
                .OrderBy(c => c.ModelId)
                .ToListAsync();
        }
    }
}
