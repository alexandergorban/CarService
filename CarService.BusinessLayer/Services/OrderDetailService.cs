using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Abstractions;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.Shared.Exceptions;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Services
{
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<OrderDetail> _repository;
        private readonly AbstractValidator<OrderDetailDto> _validator;

        public OrderDetailService(IMapper mapper,
            IRepository<OrderDetail> repository,
            AbstractValidator<OrderDetailDto> validator) : base(mapper, repository, validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        public override async Task<OrderDetailDto> AddEntityAsync(OrderDetailDto entity)
        {
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException();
            }

            var mapedEntity = _mapper.Map<OrderDetailDto, OrderDetail>(entity);
            await _repository.AddEntityAsync(mapedEntity);

            if (!_repository.SaveAsync().Result)
            {
                throw new Exception("Adding OrderDetail failed on save.");
            }

            return _mapper.Map<OrderDetail, OrderDetailDto>(mapedEntity);
        }
    }
}
