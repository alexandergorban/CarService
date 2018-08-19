using System;
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
            RuleFor(a => a.DataFirst)
                .NotNull()
                .NotEmpty();

            RuleFor(a => a.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);

            RuleFor(a => a.EMail)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);
        }
    }
}
