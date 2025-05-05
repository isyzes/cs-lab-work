using System.Text;

namespace lab3_app
{
    public class Car
    {
        private readonly static double TIRE_PRESSURE_NORM = 1.0;
        private string brand;           // марка
        private string model;           // модель
        private int tankVolume;         // объем бензобака (в литрах)
        private int fuelAmount;         // количество бензина (в литрах)
        private int currentSpeed;       // текущая скорость (в км/ч)
        private int fuelConsumption;    // расход топлива (л/100 км)
        private double[] tirePressures; // давление в каждом колесе (массив)

        public Car()
        {
            double[] pressures = [2.2, 2.3, 2.1, 2.2];
            this.brand = "Toyota";
            this.model = "Camry";
            this.tankVolume = 60;
            this.fuelAmount = 45;
            this.currentSpeed = 0;
            this.fuelConsumption = 8;
            this.tirePressures = pressures;
        }

        public Car(string brand, string model) : this()
        {
            this.brand = brand;
            this.model = model;
        }

        public Car(string brand,
                    string model,
                    int tankVolume,
                    int fuelAmount,
                    int currentSpeed,
                    int fuelConsumption,
                    double[] tirePressures)
        {
            this.brand = brand;
            this.model = model;
            this.tankVolume = tankVolume;
            if (tankVolume > fuelAmount)
            {
                this.fuelAmount = fuelAmount;
            }
            else
            {
                this.fuelAmount = tankVolume;
            }
            this.currentSpeed = currentSpeed;
            this.fuelConsumption = fuelConsumption;
            this.tirePressures = tirePressures;
        }

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int TankVolume { get => tankVolume; set => tankVolume = value; }
        public int FuelAmount
        {
            get => fuelAmount;

            set
            {
                if (tankVolume > value)
                {
                    fuelAmount = value;
                }
                else
                {
                    fuelAmount = tankVolume;
                }
            }
        }
        public int CurrentSpeed { get => currentSpeed; set => currentSpeed = value; }
        public int FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public double[] TirePressures { get => tirePressures; set => tirePressures = value; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Автомобиль: ").Append(brand).Append(" ").Append(model).Append("\n");
            sb.Append("Объем бака: ").Append(tankVolume).Append(" л\n");
            sb.Append("Топливо: ").Append(fuelAmount).Append(" л\n");
            sb.Append("Скорость: ").Append(currentSpeed).Append(" км/ч\n");
            sb.Append("Расход: ").Append(fuelConsumption).Append(" л/100 км\n");
            sb.Append("Давление в шинах: ");
            for (int i = 0; i < tirePressures.Length; i++)
            {
                sb.Append(tirePressures[i]).Append(" бар");
                if (i < tirePressures.Length - 1) sb.Append(", ");
            }
            return sb.ToString();
        }

        public int ComputeRemainingDistance() // b. метод для определения максимального пробега на оставшемся топливе
        {
            return fuelAmount * fuelConsumption * 100;
        }

        public bool HasFlatTire()//c. метод, определяющий пробой колеса (если хотя бы в одном колесе давление меньше нормы – автомобиль останавливается)
        {
            foreach (double pressure in this.tirePressures)
            {
                if (pressure < TIRE_PRESSURE_NORM)
                {
                    this.currentSpeed = 0;
                    return true;
                }
            }

            return false;
        }

        public bool IsFasterThan(Car other) //d. метод, определяющий более быстрый автомобиль из двух (возвращает true, если скорость текущего авто выше)
        {
            return this.currentSpeed > other.currentSpeed;
        }

        public static Car FasterCar(Car first, Car second, Car third) //e. статический метод, определяющий более быстрый автомобиль из трех (возвращает авто, чья скорость выше)
        {
            if (first.currentSpeed > second.currentSpeed && first.currentSpeed > third.currentSpeed)
            {
                return first;
            }

            if (second.currentSpeed > first.currentSpeed && second.currentSpeed > third.currentSpeed)
            {
                return second;
            }

            return third;
        }
    }
}