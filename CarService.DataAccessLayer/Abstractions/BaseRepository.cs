using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.DataAccessLayer.Data;
using CarService.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataAccessLayer.Abstractions
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly CarServiceDbContext _context;
        private readonly IMapper _mapper;

        protected BaseRepository(CarServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TEntity>> GetEntitiesAsync()
        {
            return await _context.Set<TEntity>()
                .OrderBy(e => e.Id)
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetEntityAsync(Guid entityId)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == entityId);
        }

        public virtual async Task AddEntityAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task UpdateEntityAsync(TEntity entity)
        {
            var entiryFromRepo = await _context.Set<TEntity>().FirstAsync(e => e.Id == entity.Id);
            _mapper.Map(entity, entiryFromRepo);
        }

        public virtual async Task DeleteEntityAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public async Task<bool> EntityExistsAsync(Guid entityId)
        {
            return await _context.Set<TEntity>().AnyAsync(c => c.Id == entityId);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
