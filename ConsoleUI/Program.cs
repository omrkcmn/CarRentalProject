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
            CarDetails();
            NewMethod();
        }

        private static void NewMethod()
        {
            CarManager update = new CarManager(new EfCarDal());
            update.Update(new Car { BrandId = 3, CarId = 7, ColorId = 2, ModelYear = "2020", Description = "Honda 20 bin km", Name = "HN" });
        }

        private static void CarInsert()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { DailyPrice = 150, Description = "Tesla Model3", ModelYear = "2022", Name = "TS",BrandId=1,ColorId=2 });
        }


        





        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.carName + " / " + item.brandName + " / "  + item.dailyPrice);
            }
        }
    }
}


/*Console.WriteLine();
Console.WriteLine("EKLEME İŞLEMİ");
Console.WriteLine("=========================================");

carManager.Add(new Car {BrandId=1,ModelYear="2021",DailyPrice=120,ColorId=45,CarId=10,Description="Honda",Name="AB"});
*/
/*Console.WriteLine();
            Console.WriteLine("GÜNCELLEME İŞLEMİ");
            Console.WriteLine("=========================================");

            carManager.Update(new Car { BrandId = 1, CarId = 10, ColorId = 45, DailyPrice = 120, Description = "Artık Honda Değil", ModelYear = "2032" });

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine();
            Console.WriteLine("SİLME İŞLEMİ");
            Console.WriteLine("=========================================");

            carManager.Delete(new Car { BrandId = 1, ModelYear = "2021", DailyPrice = 120, ColorId = 45, CarId = 10, Description = "Honda" });


            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }*/