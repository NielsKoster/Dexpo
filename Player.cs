using System;
using Zuul;
using ZuulCS;

namespace ZuulCS
{
    public class Player
    {
        public Room currentRoom;
        public float health = 100;
        private Inventory inventory = new Inventory();

        public void damage(float amount)
        {
            health -= amount;
        }

        private void heal(float amount)
        {
            health += amount;
        }

        public void isAlive()
        {
            if (health <= 0)
            {
                Console.WriteLine("You've died!");
            }
            else
            {
                Console.WriteLine("Your current health is " + health);
            }
        }
    }
}
