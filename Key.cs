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
            string direction = command.getThirdWord();
            Room ToBeUnlocked = player.currentRoom.getExit(direction);

            Console.WriteLine(direction);

            if (!command.hasThirdWord())
            {
                Console.WriteLine("Use the key in which direction?");
            }

            if (ToBeUnlocked == null)
            {
                Console.WriteLine("Can't find a door in that direction!");
            }
            else
            {
                if (!ToBeUnlocked.isLocked)
                {
                    Console.WriteLine("That door doesn't seem to be locked");
                }
                else
                {
                    ToBeUnlocked.isLocked = false;
                    Console.WriteLine("Unlocked door!");
                } 
            }
        }
    }
}
