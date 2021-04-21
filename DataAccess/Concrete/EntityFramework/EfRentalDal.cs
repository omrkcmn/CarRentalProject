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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from c in db.Cars
                             join r in db.Rentals
                             on c.CarId equals r.CarId
                             join cus in db.Customers
                             on r.UserId equals cus.id
                             join u in db.Users
                             on cus.UserId equals u.Id
                             select new RentDetailDto
                             {
                                 rentDate = r.RentDate,
                                 //returnDate = r.ReturnDate,
                                 userName = u.FirstName,
                                 userLastName = u.LastName,
                                 carDescription = c.Description,
                                 email = u.Email
                             };
                return result.ToList();
            }
        }
    }
}