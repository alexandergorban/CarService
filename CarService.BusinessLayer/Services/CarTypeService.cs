using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.Shared.Exceptions;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Services
{
    public class CarTypeService : IService<CarTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CarType> _repository;
        private readonly AbstractValidator<CarTypeDto> _validator;

        public CarTypeService(IMapper mapper,
            IRepository<CarType> repository,
            AbstractValidator<CarTypeDto> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public async Task<IEnumerable<CarTypeDto>> GetEntitiesAsync()
        {
            var data = await _repository.GetEntitiesAsync();
            return _mapper.Map<IEnumerable<CarType>, IEnumerable<CarTypeDto>>(data);
        }

        public async Task<CarTypeDto> GetEntityAsync(Guid entityId)
        {
            var data = await _repository.GetEntityAsync(entityId);
            if (data == null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<CarType, CarTypeDto>(data);
        }

        public async Task<CarTypeDto> AddEntityAsync(CarTypeDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<CarTypeDto, CarType>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding CarType failed on save.");
            }

            return _mapper.Map<CarType, CarTypeDto>(mapedEntity);
        }

        public async Task<CarTypeDto> UpdateEntityAsync(CarTypeDto entity)
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

            var mapedEntity = _mapper.Map<CarTypeDto, CarType>(entity);
            await _repository.UpdateEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Updating CarType failed on save.");
            }

            return _mapper.Map<CarType, CarTypeDto>(mapedEntity);
        }

        public async Task DeleteEntityAsync(Guid entityId)
        {
            var airplaneTypeFromRepo = await _repository.GetEntityAsync(entityId);
            if (airplaneTypeFromRepo == null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteEntityAsync(airplaneTypeFromRepo);
            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Deleting CarType failed on save.");
            }
        }
    }
}
