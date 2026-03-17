using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Car
    {
        public string _name;
        private int _horsePower=100;

        public int HorsePower 
        {
            get
            {
                if(_horsePower < 100)
                {
                    Console.WriteLine("Cant drive");
                    return _horsePower;
                }
                Console.WriteLine("can drive");
                return _horsePower;
            }
            set
            {
                if (value < 100)
                {
                    Console.WriteLine("Please enter valid power.");
                    return;
                }
                
                
                    _horsePower = value;
                Console.WriteLine($"Horse power changed to: {_horsePower}");
                
            }
        }
    }
}
