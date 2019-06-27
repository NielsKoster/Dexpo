using System;
using System.Collections.Generic;


namespace ZuulCS
{
    public class Inventory
    {
        Dictionary<string, Item> Items = new Dictionary<string, Item>();

        public Inventory() {
            this.Items = new Dictionary<string, Item>();
        }
        public void Additem(string name, Item item)
        {
            if (item == null){
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                this.Items[name] = item;
            } 
        }

        public void Removeitem(string name, Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                this.Items.Remove(name);
            }
        }

        public void Swapitems(Inventory other, string name, Item item)
        {
            
            if (name == null)
            {
                Console.WriteLine("Couldn't find that item! Did you write it correctly?");
            }
            else
            {
                this.Items[name] = item;
                other.Items.Remove(name);
            }
            
        }

        public string printContents()
        {
            string ret = "";

            if (!this.isEmpty())
            {
                foreach (KeyValuePair<string, Item> entry in Items)
                {
                    ret += entry.Key + ", ";
                }
            } else
            {
                ret += "Inventory is empty!";
            }

            return ret;
        }

        public bool isEmpty() {
            return this.Items.Count == 0;
        }

        public bool checkItem(string name)
        {
            if (Items.ContainsKey(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<string, Item> getItems()
        {
            return this.Items;
        }
    }
}
