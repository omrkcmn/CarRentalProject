using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        List<Car> _car;
        public void Delete(int carId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                Car carToDelete = _car.SingleOrDefault(c => c.CarId == carId);
                context.Cars.Remove(carToDelete);
                context.SaveChanges();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            //bu join işlemi
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in context.Cars
                             join p in context.Brands
                             on c.BrandId equals p.Id
                             select new CarDetailDto
                             {
                                 brandName = c.Name,
                                 CarId = c.CarId,
                                 dailyPrice = c.DailyPrice,
                                 
                             };
                return result.ToList();
            }
        }

        public void Update(Car carID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Car carToUpdate = _car.SingleOrDefault(c => c.CarId == carID.CarId);
                carToUpdate.BrandId = carID.BrandId;
                carToUpdate.ColorId = carID.ColorId;
                carToUpdate.DailyPrice = carID.DailyPrice;
                carToUpdate.Description = carID.Description;
                carToUpdate.ModelYear = carID.ModelYear;
                carToUpdate.Name = carID.Name;
                db.SaveChanges();
            }
        }
    }
}
