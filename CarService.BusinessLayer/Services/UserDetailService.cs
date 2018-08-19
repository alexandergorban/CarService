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
    public class UserDetailService : BaseService<UserDetail, UserDetailDto>
    {
        public UserDetailService(IMapper mapper,
            IRepository<UserDetail> repository,
            AbstractValidator<UserDetailDto> validator) : base(mapper, repository, validator)
        {

        }
    }
}
