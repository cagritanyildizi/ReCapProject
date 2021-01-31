using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId="Opel", ColorId="Black", DailyPrice=250, ModelYear=2021, Description="Aracımızın tüm bakımları yapılmış olup full yakıt müşteriye teslim edilir." },
                new Car{Id=1, BrandId="Opel", ColorId="White", DailyPrice=150, ModelYear=2021, Description="Aracımızın tüm bakımları yapılmış olup full yakıt müşteriye teslim edilir." },
                new Car{Id=2, BrandId="Nissan", ColorId="Blue", DailyPrice=300, ModelYear=2021, Description="Aracımızın tüm bakımları yapılmış olup full yakıt müşteriye teslim edilir." },
                new Car{Id=3, BrandId="Bmw", ColorId="Red", DailyPrice=300, ModelYear=2021, Description="Aracımızın tüm bakımları yapılmış olup full yakıt müşteriye teslim edilir." },
                new Car{Id=4, BrandId="Toyota", ColorId="Black", DailyPrice=250, ModelYear=2021, Description="Aracımızın tüm bakımları yapılmış olup full yakıt müşteriye teslim edilir." }
            };
        }
        
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
