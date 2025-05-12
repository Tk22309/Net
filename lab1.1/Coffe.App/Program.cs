using System;
using Coffe.Common;

namespace Coffe.App
{
    class Program
    {
        static int SmallCup = 1000;
        static int MediumCup = 1000;
        static int Coffee = 1000;
        static int Milk = 1000;
        static int CocoaPowder = 1000;
        static int Cream = 1000;

        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("Залишок інгредієнтів:");
                PrintIngredients();

                System.Console.WriteLine("\nЩо бажаєте замовити?");
                System.Console.WriteLine("1 - Еспресо");
                System.Console.WriteLine("2 - Капучино");
                System.Console.WriteLine("3 - Какао");
                System.Console.WriteLine("4 - Раф");
                System.Console.WriteLine("0 - Вийти");
                System.Console.Write("Ваш вибір: ");
                string input = System.Console.ReadLine();

                if (input == "0")
                {
                    System.Console.WriteLine("Дякуємо за використання програми!");
                    break;
                }

                System.Console.Clear();

                switch (input)
                {
                    case "1":
                        MakeEspresso();
                        break;
                    case "2":
                        MakeCappuccino();
                        break;
                    case "3":
                        MakeCocoa();
                        break;
                    case "4":
                        MakeRaf();
                        break;
                    default:
                        System.Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                System.Console.WriteLine("\nОновлений залишок інгредієнтів:");
                PrintIngredients();

                System.Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                System.Console.ReadKey();
                System.Console.Clear();
            }
        }

        static void MakeEspresso()
        {
            var drink = new Espresso();
            if (Coffee >= drink.Coffee && SmallCup >= drink.SmallCup)
            {
                Coffee -= drink.Coffee;
                SmallCup -= drink.SmallCup;
                System.Console.WriteLine("Еспресо приготовано!");
            }
            else
            {
                System.Console.WriteLine("Недостатньо інгредієнтів для еспресо!");
            }
        }

        static void MakeCappuccino()
        {
            var drink = new Cappuccino();
            if (Coffee >= 8 && Milk >= drink.Milk && MediumCup >= drink.MediumCup)
            {
                Coffee -= 8;
                Milk -= drink.Milk;
                MediumCup -= drink.MediumCup;
                System.Console.WriteLine("Капучино приготовано!");
            }
            else
            {
                System.Console.WriteLine("Недостатньо інгредієнтів для капучино!");
            }
        }

        static void MakeCocoa()
        {
            var drink = new Cocoa();
            if (Milk >= drink.Milk && CocoaPowder >= drink.CocoaPowder && SmallCup >= 1)
            {
                Milk -= drink.Milk;
                CocoaPowder -= drink.CocoaPowder;
                SmallCup -= 1;
                System.Console.WriteLine("Какао приготовано!");
            }
            else
            {
                System.Console.WriteLine("Недостатньо інгредієнтів для какао!");
            }
        }

        static void MakeRaf()
        {
            var drink = new Raf();
            if (Coffee >= 8 && Milk >= 200 && MediumCup >= 1 && Cream >= drink.Cream)
            {
                Coffee -= 8;
                Milk -= 200;
                MediumCup -= 1;
                Cream -= drink.Cream;
                System.Console.WriteLine("Раф приготовано!");
            }
            else
            {
                System.Console.WriteLine("Недостатньо інгредієнтів для рафу!");
            }
        }

        static void PrintIngredients()
        {
            System.Console.WriteLine($"- SmallCup: {SmallCup}");
            System.Console.WriteLine($"- MediumCup: {MediumCup}");
            System.Console.WriteLine($"- Coffee: {Coffee}");
            System.Console.WriteLine($"- Milk: {Milk}");
            System.Console.WriteLine($"- CocoaPowder: {CocoaPowder}");
            System.Console.WriteLine($"- Cream: {Cream}");
        }
    }
}
