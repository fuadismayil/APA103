using _09_UpcastingDowncastingExplicitImplicit.Exchange;
using _09_UpcastingDowncastingExplicitImplicit.Models;

namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Upcasting downcasting
            //Dog dog = new() { AvgLifeTime = 10, Name = "Rex", Breed = "German Shepherd", Gender = "Male" };
            //Eagle eagle = new() { AvgLifeTime = 35, FlySpeed = 100, Gender = "Female" };


            ////// Upcasting Implicit upcasting
            ////Animal animal = dog;
            ////Animal animal1 = eagle;

            ////// Downcasting Explicit downcasting
            ////Dog dog1 = (Dog)animal;
            ////Eagle eagle1 = (Eagle)animal;

            //Animal[] animals = { eagle, dog };

            //foreach (var animal in animals)
            //{
            //    //Eagle eagle1 = (Eagle)animal;
            //    Eagle eagle1 = animal as Eagle;
            //    if (eagle1 != null)
            //    {
            //        eagle1.Fly();
            //    }
            //    if (animal is Eagle)
            //    {
            //        Eagle eagle2 = (Eagle)animal;
            //    }
            //} 
            #endregion
            #region Unboxing-Boxing

            ////Boxing
            //int a = 5;
            //Object b = a;

            ////Unboxing
            //string c = b as string;

            //Test test = new();

            //ITest Itest = test; 
            #endregion

            Dollar dollar = new(200);

            Manat manat = new(170);

            Dollar dollar1 = manat;
            Console.WriteLine(dollar1.USD);

            Manat manat1 = (Manat)dollar;
            Console.WriteLine(manat1.AZN);
        }


    }
    //public struct Test : ITest
    //{
    //    public int X { get; set; }
    //    public void Y()
    //    {
    //        throw new NotImplementedException();
    //    }
    //};
    //public interface ITest
    //{
    //    void Y();
    //}
}