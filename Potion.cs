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
            weight = 5;
        }

        public override void Use(Player player, Game game, Command command)
        {
            player.heal(20);
        }
    }
}
