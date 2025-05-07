using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs_lab_work.lab4
{
    public class Truck : Car
    {
        public Truck(string brand, string model) : base(brand, model)
        {
        }

        public double MaxLoad { get; }
        public double CurrentLoad { get; private set; }

        public override void AddEngine(Engine engine)
        {
            if (engine is InternalCombustionEngine && this.engine == null) {
                this.engine = engine;
                Console.WriteLine("Двигатель успешно установлен!");
            } else {
                Console.WriteLine("Не удалось установить двигатель! \n Двигатель уже установлен или неверный тип двигателя!");
            }
        }

        public void Load(double weight)
        {
            if (CurrentLoad + weight > MaxLoad)
            {
                Console.WriteLine($"Превышена максимальная грузоподъемность! Максимум: {MaxLoad}т");
                return;
            }
            
            CurrentLoad += weight;
            Console.WriteLine($"Загружено {weight}т. Текущий груз: {CurrentLoad}т");
        }
    }
}