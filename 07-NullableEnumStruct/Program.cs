using System;
using _07_NullableEnumStruct.Enums;
using _07_NullableEnumStruct.Models;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Preparing);
            order1.UpdateStatus(OrderStatus.Ready);
            order1.UpdateStatus(OrderStatus.Delivered);
            Console.WriteLine();

            DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            order2.DisplayOrder();
            order2.UpdateStatus(OrderStatus.Ready);
            Console.WriteLine();

            DrinkOrder order3 = new DrinkOrder(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);
            order3.DisplayOrder();
            Console.WriteLine();

            Array drinkTypes = Enum.GetValues(typeof(DrinkType));
            for (int i = 0; i < drinkTypes.Length; i++)
            {
                Console.WriteLine(drinkTypes.GetValue(i));
            }

            Array drinkSizes = Enum.GetValues(typeof(DrinkSize));
            for (int i = 0; i < drinkSizes.Length; i++)
            {
                Console.WriteLine(drinkSizes.GetValue(i));
            }

            Array orderStatuses = Enum.GetValues(typeof(OrderStatus));
            for (int i = 0; i < orderStatuses.Length; i++)
            {
                Console.WriteLine(orderStatuses.GetValue(i));
            }
            Console.WriteLine();

            Console.WriteLine($"DrinkType.Coffee.ToString() -> {DrinkType.Coffee.ToString()}");
            Console.WriteLine($"DrinkSize.Large.ToString() -> {DrinkSize.Large.ToString()}");
            Console.WriteLine();

            DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
            DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");
            Console.WriteLine($"parsed drink: {parsedDrink}");
            Console.WriteLine($"parsed size: {parsedSize}");
            Console.WriteLine();

            decimal totalPrice = order1.Price + order2.Price + order3.Price;

            Console.WriteLine("umumi sifaris: 3");
            Console.WriteLine($"birinci sifarisin qiymeti: {order1.Price} azn");
            Console.WriteLine($"ikinci sifarisin qiymeti: {order2.Price} azn");
            Console.WriteLine($"ucuncu sifarisin qiymeti: {order3.Price} azn");
            Console.WriteLine($"umumi mebleg: {totalPrice} azn");

        }
    }
}