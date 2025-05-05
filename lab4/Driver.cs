using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class Driver
    {
        private string name;

        public Driver(string name)
        {
            this.name = name;
        }

        public void DriveCar(Car car)//ассоциация
        {
            Console.WriteLine($"{name} садится за руль {car.Brand} {car.Model}.");
            car.Drive();
        }

        public void ParkCar(Car car)
        {
            Console.WriteLine($"{name} припарковал автомобиль {car.Brand} {car.Model}.");
            car.Park();
        }
    }
}