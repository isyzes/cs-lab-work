using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class Engine
    {
        private string model;
        private double power;

        public Engine(string model, double power)
        {
            this.model = model;
            this.power = power;
        }
        public void Start()
        {
            Console.WriteLine($"Двигатель {model} запущен!");
        }

        public void Stop()
        {
            Console.WriteLine($"Двигатель {model} остановлен.");
        }
    }
}