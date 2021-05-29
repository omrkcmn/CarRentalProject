using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }
        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car carId)
        {
            _carDal.Delete(carId);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CarDetail2Dto>> GetAll()
        {
            return new DataResult<List<CarDetail2Dto>>(_carDal.GetAll(),true,Messages.ProductListed);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,Messages.ProductListed);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id).ToList(),true,Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByCarId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id).ToList(), true, Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id).ToList(),true,Messages.ProductListed);
        }

        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Car carID)
        {
           _carDal.Update(carID);
           return new SuccessResult(Messages.ProductAdded);          
        }
    }
}
