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
        Car _car;
        public void Delete(int carId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                _car = context.Cars.Where(c => c.CarId == carId).First();
                context.Cars.Remove(_car);
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

        public void Update(int carID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                _car = db.Cars.Where(c => c.CarId == carID).FirstOrDefault();
                db.Cars.Update(_car);
                db.SaveChanges();
            }
        }
    }
}
