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
        public List<CarDetailDto> GetCarDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in context.Cars
                             join brand in context.Brands
                             on c.BrandId equals brand.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             select new CarDetailDto
                             {
                                 brandName = c.Name,
                                 CarId = c.CarId,
                                 dailyPrice = c.DailyPrice,
                                 description = c.Description,
                                 carName = c.Name,
                                 colorName = color.Name
                                 
                             };
                return result.ToList();
            }
        }
    }
}
