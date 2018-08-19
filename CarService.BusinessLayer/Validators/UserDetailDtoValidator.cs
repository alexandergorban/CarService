using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Models;
using FluentValidation;

namespace CarService.BusinessLayer.Validators
{
    public class UserDetailDtoValidator : AbstractValidator<UserDetailDto>
    {
        public UserDetailDtoValidator()
        {
            RuleFor(u => u.FirstName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);

            RuleFor(u => u.EMail)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(30);
        }
    }
}
