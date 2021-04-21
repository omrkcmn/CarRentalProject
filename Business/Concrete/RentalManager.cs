using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentDal;

        public RentalManager(IRentalDal rentdal)
        {
            _rentDal = rentdal;
        }
        
        //[ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("user,admin")]
        
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckReturnDate(rental.CarId));

            if (result != null)
            {
                return result;
            }
            _rentDal.Add(rental);

            
            return new SuccessResult(Messages.CarRented);
        }

        private IResult CheckReturnDate(int id)
        {
            var result = _rentDal.GetAll(r => r.CarId == id).Last();
            
            if (result.ReturnDate != null)
            {
                return new SuccessResult(); 
            }
            return new ErrorResult(Messages.RentalReturnDateIsNull);

        }

        [SecuredOperation("user,admin")]
        [TransactionScopeAspect]
        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            if(rental.ReturnDate == null)
            {
                throw new Exception("Kirada olan bir aracı silemezsiniz!");
            }

            _rentDal.Delete(rental);

            return new SuccessResult(Messages.ProductDeleted);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentDal.GetAll(),true,Messages.ProductListed);
        }

        [SecuredOperation("user,admin")]
        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult(Messages.UserUpdated);
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            return new DataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(), true, Messages.ProductListed);
        }
    }
}
