using _06_InterfaceAbstraction.Interfaces;
namespace _06_InterfaceAbstraction.Models
{
    internal class Calculation : ICalculation
    {
        public double Calculate(double num1, double num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("error NaN: sifira bolmek olmaz");
                        return double.NaN;
                    }
                    return num1 / num2;
                default:
                    Console.WriteLine("error: yanlis emeliyyat");
                    return 0;
            }
        }
    }
}