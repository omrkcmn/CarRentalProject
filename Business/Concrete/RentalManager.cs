using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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

        public IResult Add(Rental rental)
        {
            var result = _rentDal.GetAll(r => r.CarId == rental.CarId).Last();
            
            if (result.ReturnDate != null)
            {
                _rentDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
            else
            {
                return new ErrorResult(Messages.CarRentError);
            }
            
        }

        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentDal.GetAll(),true,Messages.ProductListed);
        }

        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            return new DataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(), true, Messages.ProductListed);
        }
    }
}
