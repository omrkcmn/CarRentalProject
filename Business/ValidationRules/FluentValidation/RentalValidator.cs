using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        IRentalDal _rentDal;
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).NotEmpty();
        }
    }
}