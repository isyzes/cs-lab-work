using lab3_app;

public class Program {
     public static void Main(string[] args) {
        Car car1 = new();
        Car car2 = new("Audi", "A4");
        Car car3 = new("Ferrari", "F8", 80, 50, 320, 15, [2.5, 2.5, 2.5, 2.5]);

        Console.WriteLine(car1);
        Console.WriteLine();
        Console.WriteLine(car2);
        Console.WriteLine();
        Console.WriteLine(car3);
        Console.WriteLine();

        Console.WriteLine($"Максимальный пробег на оставшемся топливе для {car1.Brand} {car1.Model}: {car1.ComputeRemainingDistance()}");
        Console.WriteLine($"Колесо у автомобиля {car2.Brand} {car2.Model} пробито: {car2.HasFlatTire()}");

        Console.WriteLine($"{car3.Brand} {car3.Model} быстрее чем {car2.Brand} {car2.Model}: {car3.IsFasterThan(car2)}");

        Car fasterCar = Car.FasterCar(car1, car2, car3);
        Console.WriteLine();
        Console.WriteLine("Самый быстрый автомобиль");
        Console.WriteLine(fasterCar);

        Car otherCar = car1;
        otherCar.Brand = "Prototype";
        otherCar.Model = "ZS.12";
        otherCar.TankVolume = 400;
        otherCar.FuelAmount = 5000;
        otherCar.CurrentSpeed = 500;
        otherCar.FuelConsumption = 1;
        otherCar.TirePressures = [5.5, 5.5, 5.5, 5.5];
        
        Console.WriteLine();
        Console.WriteLine("Объект car1:");
        Console.WriteLine(car1);
    }
}