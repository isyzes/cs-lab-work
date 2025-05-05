using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class Garage
    {
        private static int garageCount = 1;
        private string name;
        private Car[] cars; //агрегация

        public Garage() {
            this.name = "Гараж №" + garageCount;
            garageCount++;
        }

        public void AddCar(Car car)
        {
            if(cars == null) {
                cars = new Car[1];
                cars[0] = car;
            } else {
                Car[] temp = new Car[cars.Length + 1];
                for(int i = 0; i < cars.Length; i++) {
                    temp[i] = cars[i];
                }
                temp[cars.Length] = car;
                
                cars = temp;
            }
            
            Console.WriteLine($"Автомобиль {car.Brand} {car.Model} добавлен в {name}.");
        }

        public void ShowCars()
        {
            Console.WriteLine($"Автомобили в {name}:");
            foreach (var car in cars)
            {
                Console.WriteLine($"- {car.Brand} {car.Model}");
            }
            Console.WriteLine();
        }
        
    }
}