using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class Car
    {
        private string brand;
        private string model;
        private Engine engine; // композиция

        public Car()
        {
            this.brand = "No Name";
            this.model = "No Name";
        }

        public Car(string brand, string model)
        {
            this.brand = brand;
            this.model = model;
        }

        public Car(string brand, string model, Engine engine)
        {
            this.brand = brand;
            this.model = model;
            this.engine = engine;
        }

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }

        public void Drive()
        {
            if (engine != null) {
                Console.WriteLine($"{Brand} {Model} поехал!");
                engine.Start();
            } else {
                Console.WriteLine($"У {Brand} {Model} нету двигателя!");
            }
            
        }

        public void Park()
        {
            if (engine != null) {
                Console.WriteLine($"{Brand} {Model} припаркован.");
                engine.Stop();
            } else {
                Console.WriteLine($"У {Brand} {Model} нету двигателя!");
            }    
        }
    }
}