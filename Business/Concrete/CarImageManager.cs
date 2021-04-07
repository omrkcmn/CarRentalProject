using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckMaxImageNumberByCarId(carImage.CarId));

            if(carImage.ImagePath != null)
            {
                string prefix = Guid.NewGuid().ToString();
                Bitmap b = new Bitmap(carImage.ImagePath);
                b.Save(@"F:\VisualProjects\CarRentalProject\IMAGES\" + prefix + ".jpg");
                carImage.ImagePath = @"F:\VisualProjects\CarRentalProject\IMAGES\" + prefix + ".jpg";
                carImage.Date = DateTime.Now;
            }
            else
            {
                carImage.ImagePath = @"E:\PROFIL.png";
            }
            if (result != null)
            {
                  return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(), true, Messages.ImageAdded);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id),true);
        }

        public IResult Update(CarImage carImage)
        {
            string prefix = Guid.NewGuid().ToString();
            Bitmap b = new Bitmap(carImage.ImagePath);
            b.Save(@"F:\VisualProjects\CarRentalProject\IMAGES\" + prefix + ".jpg");
            carImage.ImagePath = @"F:\VisualProjects\CarRentalProject\IMAGES\" + prefix + ".jpg";
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(); 
        }

        private IResult CheckMaxImageNumberByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult(Messages.MaxImageError);
            }
            return new SuccessResult();
        }
    }
}
