using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice + "TL");
                Console.WriteLine(car.Description);
                Console.WriteLine("*******");


            }
        }
    }
}
