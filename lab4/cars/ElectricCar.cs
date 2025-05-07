using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    
    public class ElectricCar : Car 
    {
        private int batteryCapacity;
        private int currentCharge;

        public ElectricCar(string brand, string model) : base(brand, model)
        {
        }

        public override void AddEngine(Engine engine)
        {
            if (engine is ElectricEngine && this.engine == null) {
                this.engine = engine;
                Console.WriteLine("Двигатель успешно установлен!");
            } else {
                Console.WriteLine("Не удалось установить двигатель! \n Двигатель уже установлен или неверный тип двигателя!");
            }
        }

        public new void DisplayInfo()
        {
            Console.WriteLine($"Тип: Электромобиль, Батарея: {batteryCapacity}кВт*ч, Заряд: {currentCharge}%");
        }

    
    }
}