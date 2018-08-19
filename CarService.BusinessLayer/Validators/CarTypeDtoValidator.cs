using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Validators
{
    public class CarTypeDtoValidator : AbstractValidator<CarTypeDto>
    {
        public CarTypeDtoValidator()
        {
            RuleFor(ct => ct.ModelId)
                .NotNull()
                .NotEmpty();

            RuleFor(ct => ct.Model)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);
        }
    }
}
