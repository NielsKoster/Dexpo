using System;
using ZuulCS;

namespace ZuulCS
{
    public class Player
    {
        public Room currentRoom;
        public float health = 20;
        private float maxweight = 5;
        public int currentweight = 0;

        private Inventory inventory = new Inventory();

        public void damage(float amount)
        {
            health -= amount;
        }

        public void heal(float amount)
        {
            health += amount;
        }

        public bool isAlive()
        {
            if (health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You've died!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Your current health is " + health);
                Console.ForegroundColor = ConsoleColor.Gray;
                return true;
            }
        }

        public Inventory getInventory()
        {
            return this.inventory;
        }

        public float getMaxWeight()
        {
            return maxweight;
        }
        public float getCurrentWeight()
        {
            return currentweight;
        }
    }
}
