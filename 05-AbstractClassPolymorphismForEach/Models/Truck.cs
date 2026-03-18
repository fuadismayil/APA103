using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }
        public int MaxSpeed { get; set; }

        public Truck(string Brend, string Model, int Year, string PlateNumber, double FuelLevel, double CargoCapacity, int AxleCount, double CurrentLoad, int MaxSpeed):base(Brend, Model, Year, PlateNumber, FuelLevel)
        {
            this.CargoCapacity = CargoCapacity;
            this.AxleCount = AxleCount;
            this.CurrentLoad = CurrentLoad;
            this.MaxSpeed = MaxSpeed;
        }


        public void ShowTruckInfo()
        {
            Console.WriteLine($"Brand: {Brend}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}%, Cargo Capacity: {CargoCapacity} tons, Axle Count: {AxleCount}, Current Load: {CurrentLoad} tons, Max Speed: {MaxSpeed} km/h");
        }

        public double LoadCargo(double weight)
        {
            return CurrentLoad+weight;
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }

    }
}