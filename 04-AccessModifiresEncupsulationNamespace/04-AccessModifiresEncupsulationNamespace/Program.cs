using _04_AccessModifiresEncupsulationNamespace.Models;
using System.Reflection;

namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student();

            //Console.WriteLine(student.name);

            


            Person person = new Person();
            ////Console.WriteLine(person.name);
            typeof(Person).GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(person, "John");
            var newName = typeof(Person).GetField("name", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);
            //Console.WriteLine(newName);
            person.ShowInfo();

            Car car = new Car();
            car.HorsePower = 50;
            Console.WriteLine(car.HorsePower);
        }
    }
}
