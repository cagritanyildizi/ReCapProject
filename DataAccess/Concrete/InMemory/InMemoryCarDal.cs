using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear = 2006,DailyPrice = 150,Description = "Toyota Corolla 1.4"},
                new Car{Id = 2,BrandId = 2,ColorId = 3,ModelYear = 2020,DailyPrice = 350,Description = "Renault Megane"},
                new Car{Id = 3,BrandId = 3,ColorId = 4,ModelYear = 1994,DailyPrice = 100,Description = "Opel Vectra"},
                new Car{Id = 4,BrandId = 3,ColorId = 5,ModelYear = 2010,DailyPrice = 175,Description = "Fiat Doblo"},
                new Car{Id = 5,BrandId = 4,ColorId = 7,ModelYear = 2004,DailyPrice = 240,Description = "Audi A4"},
                new Car{Id = 6,BrandId = 5,ColorId = 12,ModelYear = 2015,DailyPrice = 250,Description = "Hyundai İ20"}
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.ModelYear = car.ModelYear;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
        }
    }
}