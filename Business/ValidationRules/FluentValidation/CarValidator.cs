using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("The model year is not null");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("The daily price is not null");
            RuleFor(c => c.Description).NotEmpty().WithMessage("The description is not null");
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("The description is not be less than 2 characters");
        }
    }
}
