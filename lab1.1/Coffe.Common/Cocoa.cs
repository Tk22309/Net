using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class Cocoa : Drink
    {
        public int Milk { get; set; }
        public int CocoaPowder { get; set; }
        public static string Type = "Гарячий напій";

        static Cocoa()
        {
            Console.WriteLine("Клас Cocoa ініціалізовано");
        }

        public Cocoa() : base("Cocoa", 220)
        {
            Milk = 200;
            CocoaPowder = 20;
        }
    }
}