using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class Cappuccino : Espresso
    {
        public new static Cappuccino CreateNew() => new Cappuccino();

        public int Milk { get; set; }
        public int MediumCup { get; set; }

        public Cappuccino()
        {
            Milk = 200;
            MediumCup = 1;
        }
    }
}