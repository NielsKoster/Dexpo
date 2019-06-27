using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulCS
{
    public class Key: Item
    {
        public Key()
        {
            description = "a key";
            weight = 3;
        }

        public override void Use(Player player, Game game, Command command)
        {
            game.UnlockDoor(command); 
        }
    }
}
