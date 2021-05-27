using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarInsert();

            //UpdateCar();


            //Delete();

            //CarDetails();

            //UserAdd();
            //GetUsers();
            //RentCar();
            //RentView();
            //ReturnCar();
        }
        /*
        private static void ReturnCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Update(new Rental { Id=5, RentDate = DateTime.Now, ReturnDate = DateTime.Now }).ToString());
        }

        private static void RentView()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentDetails();
            Console.WriteLine("Kiralayan");
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.carDescription + " " + item.userName + " " + item.userLastName + " " + item.rentDate);
            }
        }

        private static void RentCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 10, CustomerId = 2, RentDate = DateTime.Now,ReturnDate=null}));
        }



        private static void GetUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Ahmet Sefa", LastName = "Çelik", Email = "asc@yahoo.com", Password = "asç" });
        }

        private static void Delete()
        {
            CarManager delete = new CarManager(new EfCarDal());
            //delete.Delete(1);
        }

        private static void UpdateCar()
        {
            CarManager update = new CarManager(new EfCarDal());
            update.Update(new Car { BrandId = 1, CarId = 1, ColorId = 2, DailyPrice = 120, Description = "Artık Tesla Değil", ModelYear = "2032",Name="HN" });

        }

        private static void CarInsert()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 150, Description = "Toros Araç", ModelYear = "1956", Name = "TR",BrandId=1,ColorId=3 });
        }

        /*
        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarId + " / " + item.brandName + " / "  + item.description + " / " +item.colorName);
            }
        }*/
    }
}