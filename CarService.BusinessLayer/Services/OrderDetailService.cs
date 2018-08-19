using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarService.BusinessLayer.Abstractions;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Services
{
    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDto>
    {
        public OrderDetailService(IMapper mapper,
            IRepository<OrderDetail> repository,
            AbstractValidator<OrderDetailDto> validator) : base(mapper, repository, validator)
        {

        }
    }
}
