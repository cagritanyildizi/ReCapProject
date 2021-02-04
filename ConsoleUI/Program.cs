using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            ICarService carService = new CarManager(new EfCarDal());
            carService.Add(new Car
            {
                BrandId = 1,
                ColorId = 3,
                DailyPrice = 0,
                ModelYear = 2004,
                Description = "T"
            });
            foreach (var car in carService.GetCarsByBrandId(1))
            {
                Console.WriteLine("Arabanın Marka ve Modeli: {0} Arabanın Yılı: {1} Günlük Ücret: {2}", car.Description, car.ModelYear, car.DailyPrice);
            }

            Console.ReadLine();
        }
    }
}