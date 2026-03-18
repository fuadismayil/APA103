using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public int MaxSpeed { get; set; }


        public Car(string Brend, string Model, int Year, string PlateNumber, double FuelLevel, int DoorCount, int TrunkCapacity, bool IsAutomatic, int  MaxSpeed): base(Brend, Model, Year, PlateNumber, FuelLevel)
        {
            this.DoorCount = DoorCount;
            this.TrunkCapacity = TrunkCapacity;
            this.IsAutomatic = IsAutomatic;
            this.MaxSpeed = MaxSpeed;      
        }


        public void ShowCarInfo()
        {
            Console.WriteLine($"Brand: {Brend}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}%, Door Count: {DoorCount}, Trunk Capacity: {TrunkCapacity} liters, Is Automatic: {IsAutomatic}, Max Speed: {MaxSpeed} km/h");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.5;
        }
    }
}