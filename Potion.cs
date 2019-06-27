using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulCS
{
    class Potion: Item
    {
        public Potion()
        {
            this.description = "a mysterious potion";
            this.weight = 1;
        }

        public void Use()
        {
            Console.WriteLine("Damage player!");
        }
    }
}
