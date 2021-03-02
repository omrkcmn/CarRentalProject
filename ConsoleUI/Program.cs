using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryProductDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
            
            
            Console.WriteLine();
            Console.WriteLine("EKLEME İŞLEMİ");
            Console.WriteLine("=========================================");

            carManager.Add(new Car {BrandId=1,ModelYear="2021",DailyPrice=120,ColorId=45,CarId=10,Description="Honda" });
            
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine();
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
            }
        }
    }
}
