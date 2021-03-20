using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarInsert();

            //UpdateCar();

            
            //Delete();

            CarDetails();
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
            carManager.Add(new Car { DailyPrice = 150, Description = "Tesla Model Y", ModelYear = "2020", Name = "TS",BrandId=1,ColorId=3 });
        }


        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarId + " / " + item.brandName + " / "  + item.description + " / " +item.colorName);
            }
        }
    }
}