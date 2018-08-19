using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarService.Shared.Interfaces;

namespace CarService.BusinessLayer.Interfaces
{
    public interface IService<TDto> where TDto : IModelDto
    {
        Task<IEnumerable<TDto>> GetEntitiesAsync();
        Task<TDto> GetEntityAsync(Guid entityId);
        Task<TDto> AddEntityAsync(TDto entity);
        Task<TDto> UpdateEntityAsync(TDto entity);
        Task DeleteEntityAsync(Guid entityId);
    }
}
