using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car>() { 
                new Car { BrandId=1,CarId=1,ColorId=1,DailyPrice=450,Description="Tesla Model Y",ModelYear="2021"},
                new Car { BrandId=1,CarId=2,ColorId=1,DailyPrice=550,Description="Tesla Model x",ModelYear="2021"},
                new Car { BrandId=2,CarId=3,ColorId=1,DailyPrice=550,Description="TOGG",ModelYear="2021"},
                new Car { BrandId=3,CarId=4,ColorId=1,DailyPrice=650,Description="Mercedes",ModelYear="2021"},         
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
