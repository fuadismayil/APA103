using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04_AccessModifiresEncupsulationNamespace.Models;

namespace Domain

{
   
    public class Test //: Person
    { Car car = new Car();
        public Test()
        {
            //Console.WriteLine(this.name);
        }

        public static void Check()
        {
            //Person person = new Person("John");
            Student student = new Student();
        }
    }
}
