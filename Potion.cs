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
            description = "a mysterious potion";
            weight = 4;
        }

        public override void Use(Player player, Game game, Command command)
        {
            if (player.health <= 80)
            {
                player.heal(20);
                player.isBleeding = false;
                Console.WriteLine("The bleeding has stopped! You win!");
            }
        }
    }
}
