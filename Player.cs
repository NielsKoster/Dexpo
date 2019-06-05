using System;
using ZuulCS;

namespace ZuulCS
{
    public class Player
    {
        public Room currentRoom;
        public float health = 100;

        public Player()
        {
            createRooms();
        }

        private void createRooms()
        {
            Room outside, theatre, pub, lab, office, hallway, gym, principleoffice, musicstudio, roof;

            // create the rooms
            outside = new Room("outside the main entrance of the university");
            theatre = new Room("in a lecture theatre");
            pub = new Room("in the campus pub");
            lab = new Room("in a computing lab");
            office = new Room("in the computing admin office");
            hallway = new Room("in the hallway of the university");
            gym = new Room("in the gym");
            principleoffice = new Room("in the principle's office");
            musicstudio = new Room("in the music studio");
            roof = new Room("on the roof of the university");


            // initialise room exits
            outside.setExit("north", hallway);
            outside.setExit("east", theatre);
            outside.setExit("south", lab);
            outside.setExit("west", pub);
           
            

            hallway.setExit("east", principleoffice);
            hallway.setExit("south", outside);
            hallway.setExit("west", musicstudio);
            hallway.setExit("up", roof);

            principleoffice.setExit("west", hallway);

            musicstudio.setExit("east", hallway);
            
            theatre.setExit("west", outside);

            pub.setExit("east", outside);

            lab.setExit("north", outside);
            lab.setExit("east", office);

            office.setExit("west", lab);

            roof.setExit("down", hallway);

            currentRoom = outside;  // start game outside
        }
        
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
                for (float i = 0; i < 10; i++)
                {
                    Console.WriteLine("");
                }
                Console.WriteLine("You've died!");
                for (float i = 0; i < 10; i++)
                {
                    Console.WriteLine("");
                }
            }
            else
            {
                
            }
        }

        public void printHealth()
        {
            Console.WriteLine("Your current health is " + health);
        }
    }
}
