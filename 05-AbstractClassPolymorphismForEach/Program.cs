using _05_AbstractClassPolymorphismForEach.Models;

namespace _05_AbstractClassPolymorphismForEach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Mercedes", "E200", 2023, "10-AA-001", 100, 4, 500, true, 220);
            Car car2 = new Car("BMW", "320i", 2022, "99-BB-999", 100, 4, 480, true, 235);
            Car car3 = new Car("Toyota", "Camry", 2021, "77-CC-777", 100, 4, 524, true, 210);

            Motorcycle moto1 = new Motorcycle("Yamaha", "R1", 2023, "10-MM-100", 100, 998, false, 299, "Sport");
            Motorcycle moto2 = new Motorcycle("Harley-Davidson", "Softail", 2022, "10-HH-020", 100, 1868, true, 180, "Cruiser");

            Truck truck1 = new Truck("MAN", "TGX", 2020, "99-TT-100", 100, 18, 3, 12, 120);
            Truck truck2 = new Truck("Volvo", "FH16", 2021, "99-VV-160", 100, 25, 4, 18, 110);

            Vehicle[] vehicles = { car1, car2, car3, moto1, moto2, truck1, truck2 };

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is Car car)
                {
                    car.ShowCarInfo();
                    Console.WriteLine($"Fuel cost (500 km): {car.CalculateFuelCost(500)} AZN\n");
                }
                else if (vehicles[i] is Motorcycle moto)
                {
                    moto.ShowMotorcycleInfo();
                    Console.WriteLine($"Fuel cost (300 km): {moto.CalculateFuelCost(300)} AZN\n");
                }
                else if (vehicles[i] is Truck truck)
                {
                    truck.ShowTruckInfo();
                    Console.WriteLine($"Fuel cost (800 km): {truck.CalculateFuelCost(800)} AZN\n");
                }
            }

            truck1.CurrentLoad = truck1.LoadCargo(5);
            Console.WriteLine($"MAN TGX new fuel cost (800 km): {truck1.CalculateFuelCost(800)} AZN\n");

            int totalVehicles = vehicles.Length;
            int totalSpeed = 0;
            double maxCost = 0;
            string mostExpensive = "";

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is Car c)
                {
                    totalSpeed += c.MaxSpeed;
                    double cost = c.CalculateFuelCost(100);
                    if (cost > maxCost)
                    {
                        maxCost = cost;
                        mostExpensive = $"{c.Brend} {c.Model}";
                    }
                }
                else if (vehicles[i] is Motorcycle m)
                {
                    totalSpeed += m.MaxSpeed;
                    double cost = m.CalculateFuelCost(100);
                    if (cost > maxCost)
                    {
                        maxCost = cost;
                        mostExpensive = $"{m.Brend} {m.Model}";
                    }
                }
                else if (vehicles[i] is Truck t)
                {
                    totalSpeed += t.MaxSpeed;
                    double cost = t.CalculateFuelCost(100);
                    if (cost > maxCost)
                    {
                        maxCost = cost;
                        mostExpensive = $"{t.Brend} {t.Model}";
                    }
                }
            }

            double avgSpeed = (double)totalSpeed / totalVehicles;

            Console.WriteLine($"Total vehicles: {totalVehicles}");
            Console.WriteLine($"Average Max Speed: {avgSpeed:F2} km/h");
            Console.WriteLine($"Most expensive fuel per 100km: {mostExpensive} ({maxCost} AZN)");

            Console.ReadLine();
        }
    }
}
