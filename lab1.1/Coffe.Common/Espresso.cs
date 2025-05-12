using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class Espresso : Drink
    {
        public int Coffee { get; set; }
        public int SmallCup { get; set; }

        public Espresso() : base("Espresso", 50)
        {
            Coffee = 8;
            SmallCup = 1;
        }
    }
}