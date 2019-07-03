using System;

namespace ZuulCS
{
    public class Item
    {
        protected string description;
        public int weight;
        private string secondWord;

        public Item() {
            description = "";
            weight = 1;
        }

        public virtual void Use(Player player, Game game, Command command)
        {
            Console.WriteLine("This is the use function of the item class");
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

        public float getWeight()
        {
            return weight;
        }

    }
}
