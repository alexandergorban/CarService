using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Abstractions;
using CarService.BusinessLayer.Interfaces;
using CarService.DataAccessLayer.Entities;
using CarService.DataAccessLayer.Interfaces;
using CarService.Shared.Exceptions;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Services
{
    public class CarTypeService : BaseService<CarType, CarTypeDto>
    {
        public CarTypeService(IMapper mapper,
            IRepository<CarType> repository,
            AbstractValidator<CarTypeDto> validator) : base(mapper, repository, validator)
        {
            
        }
    }
}
