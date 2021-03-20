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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Name.Length > 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car carId)
        {
            try
            {
                _carDal.Delete(carId);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true,Messages.ProductListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id).ToList(),true,Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id).ToList(),true,Messages.ProductListed);
        }

        public IResult Update(Car carID)
        {
            try
            {
                _carDal.Update(carID);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            
        }
    }
}
