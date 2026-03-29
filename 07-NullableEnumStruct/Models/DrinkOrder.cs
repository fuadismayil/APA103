using System;
using _07_NullableEnumStruct.Enums;

namespace _07_NullableEnumStruct.Models
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }= OrderStatus.New;
        public decimal Price { get; set; }

        public DrinkOrder(int OrderNumber, string CustomerName, DrinkType Drink, DrinkSize Size)
        {
            this.OrderNumber = OrderNumber;
            this.CustomerName = CustomerName;
            this.Drink = Drink;
            this.Size = Size;
            this.Price = CalculatePrice();
        }

        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 3;
                        case DrinkSize.Medium: return 4;
                        case DrinkSize.Large: return 5;
                    }
                    break;
                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 2;
                        case DrinkSize.Medium: return 3;
                        case DrinkSize.Large: return 4;
                    }
                    break;
                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 4;
                        case DrinkSize.Medium: return 5;
                        case DrinkSize.Large: return 6;
                    }
                    break;
                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small: return 1;
                        case DrinkSize.Medium: return 1.5M;
                        case DrinkSize.Large: return 2;
                    }
                    break;
            }
            return 0m;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            this.Status = newStatus;
            Console.WriteLine($"sifaris: {OrderNumber} status: {newStatus}");
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"sifaris: {OrderNumber}, musteri: {CustomerName}, icki: {Drink}, olcu: {Size}, status: {Status}, qiymet: {Price} azn");
        }
    }
}