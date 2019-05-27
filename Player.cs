using System;
using ZuulCS;

namespace Zuul
{
    public class Player
    {
        public Room currentRoom;
        public float health;

        public Player()
        {
            createRooms();
        }

        private void createRooms()
        {
            Room outside, theatre, pub, lab, office;

            // create the rooms
            outside = new Room("outside the main entrance of the university");
            theatre = new Room("in a lecture theatre");
            pub = new Room("in the campus pub");
            lab = new Room("in a computing lab");
            office = new Room("in the computing admin office");

            // initialise room exits
            outside.setExit("east", theatre);
            outside.setExit("south", lab);
            outside.setExit("west", pub);

            theatre.setExit("west", outside);

            pub.setExit("east", outside);

            lab.setExit("north", outside);
            lab.setExit("east", office);

            office.setExit("west", lab);

            currentRoom = outside;  // start game outside
        }
        
        private void damage(float amount)
        {
            health -= amount;
        }

        private void heal(float amount)
        {
            health += amount;
        }

        private bool isAlive()
        {
            if (health > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
