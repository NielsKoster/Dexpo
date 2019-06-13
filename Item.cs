using System;

namespace ZuulCS
{
    public class Item
    {
        protected string description = "";
        protected float weight = 1;

        public void getStats()
        {
            Console.WriteLine(description);
            Console.WriteLine("Weight: " + weight);
        }

        public string getDescription()
        {
            return description;
        }

    }
}
