using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }


        public Motorcycle(string Brend, string Model, int Year, string PlateNumber, double FuelLevel, int EngineCapacity, bool HasSidecar, int MaxSpeed, string Type):base(Brend, Model, Year, PlateNumber, FuelLevel)
        {
            this.EngineCapacity = EngineCapacity;
            this.HasSidecar = HasSidecar;
            this.MaxSpeed = MaxSpeed;
            this.Type = Type;
        }


        public void ShowMotorcycleInfo()
        {
            Console.WriteLine($"Brand: {Brend}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}%, Engine Capacity: {EngineCapacity} cc, Has Sidecar: {HasSidecar}, Max Speed: {MaxSpeed} km/h, Type: {Type}");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.5;
        }

    }
}