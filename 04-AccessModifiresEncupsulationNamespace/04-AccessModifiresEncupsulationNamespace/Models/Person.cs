using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Person
    {
        //internal string name;
        //protected string name;
        private string name="Test";
        public string surname;

        public Person()
        {
            this.name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{name}");
        }
    }
}
