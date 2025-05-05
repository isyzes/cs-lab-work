using cs_lab_work.lab4;

public class Program {
     public static void Main(string[] args) {
        Engine v8Engine = new Engine("V8 Turbo", 450);
        Car bmw = new Car("BMW", "M5", v8Engine);
        Car audi = new Car("Audi", "R8", v8Engine);
        Car car = new Car();

        Garage myGarage = new Garage();
        myGarage.AddCar(bmw);
        myGarage.AddCar(audi);
        myGarage.AddCar(car);
        myGarage.ShowCars();

        Garage myGarage2 = new Garage();
        myGarage2.AddCar(bmw);
        myGarage2.AddCar(audi);
        myGarage2.AddCar(car);
        myGarage2.ShowCars();

        Driver driver = new Driver("Дмитрий");
        driver.DriveCar(bmw);
        driver.ParkCar(bmw);

        Console.WriteLine();
        
        driver.DriveCar(audi);
        driver.ParkCar(audi);

        Console.WriteLine();
        
        driver.DriveCar(car);
        driver.ParkCar(car);
    }
}