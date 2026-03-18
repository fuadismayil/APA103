using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    internal abstract class Vehicle
    {
        public double _fuelLevel = 100;


        public string Brend { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }


        protected Vehicle(string Brend, string Model, int Year, string PlateNumber, double FuelLevel)
        {
            this.Brend = Brend;
            this.Model = Model;
            this.Year = Year;
            this.PlateNumber = PlateNumber;
            this.FuelLevel = FuelLevel;  
        }


        public string GetVehicleInfo()
        {
            return $"Brand: {Brend}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}%";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {Brend}, Model: {Model}, Year: {Year}");
        }
    }
}