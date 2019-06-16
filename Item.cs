using System;

namespace ZuulCS
{
    public class Item
    {
        protected string description;
        protected float weight;
        private string secondWord;

        public Item() {
            this.description = "";
            this.weight = 1;
        }

        public void getStats()
        {
            Console.WriteLine(description);
            Console.WriteLine("Weight: " + weight);
        }

        public string getDescription()
        {
            return description;
        }

        public string getSecondword()
        {
            return secondWord;
        }

        public bool hasSecondWord()
        {
            return (secondWord != null);
        }

    }
}
