using _06_InterfaceAbstraction.Models;
namespace _06_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation calculate = new Calculation();

            Console.WriteLine(calculate.Calculate(10, 5, '+'));
            Console.WriteLine(calculate.Calculate(20, 4, '-'));
            Console.WriteLine(calculate.Calculate(6, 3, '*'));
            Console.WriteLine(calculate.Calculate(15, 3, '/'));
            Console.WriteLine(calculate.Calculate(10, 0, '/'));
        }
    }
}