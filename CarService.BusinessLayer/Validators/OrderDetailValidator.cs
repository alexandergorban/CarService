﻿using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Validators
{
    public class OrderDetailValidator : AbstractValidator<OrderDetailDto>
    {
        public OrderDetailValidator()
        {
            RuleFor(o => o.DataFirst)
                .NotNull()
                .NotEmpty();

            RuleFor(o => o.UserDetail)
                .NotNull()
                .NotEmpty();
        }
    }
}
