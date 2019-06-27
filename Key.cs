using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulCS
{
    public class Key: Item
    {
        public Key()
        {
            description = "a key";
            weight = 1;
        }

        public void Use()
        {
            Console.WriteLine("That won't work. Please use the " + "'open'" + " command to use this key to open a door.");
        }
    }
}
