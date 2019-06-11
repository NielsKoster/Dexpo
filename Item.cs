using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class Item
    {
        protected string description = "";
        protected float weight = 1;

        public void getStats()
        {
            Console.WriteLine(description);
            Console.WriteLine("Weight: " + weight);
        }

    }
}
