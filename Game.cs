using System;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        public Player player;

        public Game()
        {
            player = new Player();
            parser = new Parser();

            createRooms();
        }

        /**
	     *  Main play routine.  Loops until end of play.
	     */

        public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
                if (player.isAlive())
                {
                    Command command = parser.getCommand();
                    finished = processCommand(command);
                } else
                {
                    finished = true;
                }
			}
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("");
            Console.WriteLine("            .o8                                             ");
            Console.WriteLine("            888                                             ");
            Console.WriteLine("       .oooo888   .ooooo.  oooo    ooo oo.ooooo.   .ooooo.  ");
            Console.WriteLine("      d88' `888  d88' `88b  `88b..8P'   888' `88b d88' `88b ");
            Console.WriteLine("      888   888  888ooo888    Y888'     888   888 888   888");
            Console.WriteLine("      888   888  888    .o  .o8 88b     888   888 888   888");
            Console.WriteLine("       Y8bod88P   Y8bod8P' o88'   888o  888bod8P' `Y8bod8P'");
            Console.WriteLine("                                        888                ");
            Console.WriteLine("                                       o888o                ");
            Console.WriteLine("");

            Console.WriteLine("Welcome to Dexpo!");
			Console.WriteLine("In this game you will need to navigate an area arround a university.");
			Console.WriteLine("You have been stabbed and are bleeding.");
			Console.WriteLine("You will begin with 100 hp, but it will run out after a while!");
			Console.WriteLine("The goal is to find an health kit to stop the bleeding.");
			Console.WriteLine("Type 'help' if you need further help.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

        private void createRooms()
        {
            Room outside, theatre, pub, lab, office, hallway, gym, principleoffice, musicstudio, roof;
            Key key = new Key();
            Potion potion = new Potion();
            Candle candle = new Candle();

            // create the rooms
            outside = new Room("outside the main entrance of the university");
            theatre = new Room("in a lecture theatre");
            pub = new Room("in the campus pub");
            lab = new Room("in a computing lab");
            office = new Room("in the computing admin office");
            hallway = new Room("in the hallway of the university");
            gym = new Room("in the university's gym");
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
            principleoffice.GetInventory().Additem("key",key);

            musicstudio.setExit("east", hallway);

            theatre.setExit("west", outside);

            pub.setExit("east", outside);
            pub.GetInventory().Additem("potion", potion);

            lab.setExit("north", outside);
            lab.setExit("east", office);
            lab.GetInventory().Additem("candle", candle);

            office.setExit("west", lab);
            office.isLocked = true;
            office.GetInventory().Additem("potion", potion);

            roof.setExit("down", hallway);

            player.currentRoom = outside;  // start game outside
        }

        /**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
        private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
                    break;
                case "look":
                    Console.WriteLine(player.currentRoom.getLongDescription());
                    break;
                case "quit":
					wantToQuit = true;
					break;
                case "health":
                    player.isAlive();
                    break;
                case "take":
                    takeItem(command);
                    break;
                case "drop":
                    dropItem(command);
                    break;
                case "inventory":
                    Console.WriteLine(player.getInventory().printContents());
                    break;
                case "use":
                    useItem(command);
                    break;

            }

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
                //If the room doesn't exist...
				Console.WriteLine("There is no door to "+direction+"!");
			} else if (nextRoom.isLocked == true)
            {
                //If the room is locked...
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n The room to the " + direction + " is locked! There should be a key somewhere...");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(player.currentRoom.getLongDescription());
            }
            else { //If the player is allowed to enter the room..
                if (player.isBleeding)
                {
                    player.damage(5);
                }

                player.currentRoom = nextRoom;
				Console.WriteLine(player.currentRoom.getLongDescription());
            }
		}

        private void takeItem(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know what to take
                Console.WriteLine("Take what?");
                return;
            }
            //if the second word is in place, then we can search in the room's inventory for the given word
            string itemtotake = command.getSecondWord();
            
            //However, first we need to check if the given command actually corresponds to an existing item which is in the room's inventory
            if (player.currentRoom.GetInventory().checkItem(itemtotake))
                {
                //Check if the player actually specifically said what they wanted
                Item item = player.currentRoom.GetInventory().getItems()[command.getSecondWord()];

                //Add the weight of the item in the inventory
                player.currentweight += item.weight;

                if (player.currentweight >= player.getMaxWeight())
                {
                    Console.WriteLine("Your inventory is full, you can't pick this up.");
                    item.weight -= player.currentweight;
                }
                else
                {
                    //if the item given does correspond to an item in the room's inventory, then we can give it to the player
                    player.getInventory().Additem(itemtotake, item);
                    player.currentRoom.GetInventory().Removeitem(itemtotake, item);
                    Console.WriteLine("Took " + itemtotake);
                }
            }
            else
            {
                //Speaks for itself honestly
                Console.WriteLine("That item doesn't seem to exist. Did you write it correctly?");
            }
        }

        private void dropItem(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know what to take
                Console.WriteLine("Drop what?");
                return;
            }
            //if the second word is in place, then we can search in the room's inventory for the given word
            string itemtodrop = command.getSecondWord();

            //However, first we need to check if the given command actually corresponds to an existing item which is in the room's inventory
            if (player.getInventory().checkItem(itemtodrop))
            { 
                Item item = player.getInventory().getItems()[command.getSecondWord()];
                item.weight -= player.currentweight;
                //if the item given does correspond to an item in the room's inventory, then we can give it to the player
                player.currentRoom.GetInventory().Additem(itemtodrop, item);
                player.getInventory().Removeitem(itemtodrop, item);
                Console.WriteLine("Dropped " + itemtodrop);
            }
            else
            {
                //Speaks for itself honestly
                Console.WriteLine("That item doesn't seem to exist. Did you write it correctly?");
            }
        }

        public void useItem(Command command)
        {
            if (!command.hasSecondWord())
            {
                Console.WriteLine("Use what?");
                return;
            }

            string itemstring = command.getSecondWord();

            //If the item in question is in the player's inventory...
            if (player.getInventory().checkItem(itemstring))
            {
                player.getInventory().getItems()[itemstring].Use(player, this, command);
            }
            else
            {
                Console.WriteLine("Can't find the item to use in your inventory.");
            }
        }
    }
}
