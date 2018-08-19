using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.DataAccessLayer.Interfaces;
using CarService.Shared.Exceptions;
using CarService.Shared.Interfaces;
using FluentValidation;

namespace CarService.BusinessLayer.Abstractions
{
    public abstract class BaseService<TEntity, TDto> : IService<TDto> 
        where TEntity : IEntity
        where TDto : IModelDto
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;
        private readonly AbstractValidator<TDto> _validator;

        protected BaseService(IMapper mapper,
            IRepository<TEntity> repository,
            AbstractValidator<TDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public virtual async Task<IEnumerable<TDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(data);
        }

        public virtual async Task<TDto> GetEntityAsync(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<TEntity, TDto>(data);
        }

        public virtual async Task<TDto> AddEntityAsync(TDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TDto, TEntity>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding EntityType failed on save.");
            }

            return _mapper.Map<TEntity, TDto>(mapedEntity);
        }

        public virtual async Task<TDto> UpdateEntityAsync(TDto entity)
        {
            if (!_repository.EntityExistsAsync(entity.Id).Result)
            {
                throw new NotFoundException();
            }

            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<TDto, TEntity>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating EntityType failed on save.");
            }

            return _mapper.Map<TEntity, TDto>(mapedEntity);
        }

        public virtual async Task DeleteEntityAsync(Guid entityId)
        {
            var airplaneTypeFromRepo = await _repository.GetEntityAsync(entityId);
            if (airplaneTypeFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(airplaneTypeFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting EntityType failed on save.");
            }
        }
    }
}
