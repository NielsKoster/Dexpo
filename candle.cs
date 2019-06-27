using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulCS
{
    class Candle: Item
    {
        public Candle()
        {
            description = "a hot flame";
            weight = 1;
        }

        public override void Use(Player player, Game game, Command command)
        {
            Console.WriteLine("Ahh! That burns!!");
            player.damage(15);
        }
    }
}
