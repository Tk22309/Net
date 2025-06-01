using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class Raf : Cappuccino
    {
        public new static Raf CreateNew() => new Raf();

        public int Cream { get; set; }

        public delegate void OnCreamAddedHandler(string message);
        public event OnCreamAddedHandler OnCreamAdded;

        public Raf()
        {
            Cream = 50;
            OnCreamAdded?.Invoke("Вершки додано до Raf");
        }
    }
}