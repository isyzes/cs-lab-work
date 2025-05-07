using cs_lab_work.lab4;

public class Program {
     public static void Main(string[] args) {
        Engine v8Engine = new ElectricEngine("V8 Turbo", 450);
        Car bmw = new ElectricCar("BMW", "M5");
        bmw.AddEngine(v8Engine);
        bmw.DisplayInfo();
        Console.WriteLine("---------------------------");

        Engine engine = new InternalCombustionEngine("V8 Turbo", 450, 5.2);
        Car audi = new Truck("Audi", "R8");
        audi.AddEngine(engine);
        audi.DisplayInfo();
        Console.WriteLine("---------------------------");

        ElectricCar car = new ElectricCar("Test", "12");
        car.AddEngine(engine);
        car.DisplayInfo();
        Console.WriteLine("---------------------------");

        Garage myGarage = new Garage();
        myGarage.AddCar(bmw);
        myGarage.AddCar(audi);
        myGarage.AddCar(car);
        myGarage.ShowCars();
        Console.WriteLine("---------------------------");

        Garage myGarage2 = new Garage();
        myGarage2.AddCar(bmw);
        myGarage2.AddCar(audi);
        myGarage2.AddCar(car);
        myGarage2.ShowCars();
        Console.WriteLine("---------------------------");

        Driver driver = new Driver("Дмитрий");
        driver.DriveCar(bmw);
        driver.ParkCar(bmw);
        Console.WriteLine("---------------------------");
        
        driver.DriveCar(audi);
        driver.ParkCar(audi);
        Console.WriteLine("---------------------------");
        
        driver.DriveCar(car);
        driver.ParkCar(car);
        Console.WriteLine("---------------------------");
    }
}