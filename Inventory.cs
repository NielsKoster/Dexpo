using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class Inventory
    {
        Dictionary<Item, string> Items = new Dictionary<Item, string>();

        public void Additem(Item item)
        {
            if (item == null){
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                this.Additem(item);
            } 
        }

        public void Removeitem(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                this.Items.Remove(item);
            }
        }

        public void Swapitems(Inventory other, Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                other.Items.Remove(item);

                //this.Items.Add(item, item.description);
            }
        }

    }
}
