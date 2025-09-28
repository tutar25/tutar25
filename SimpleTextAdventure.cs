using System;
using System.Collections.Generic;

namespace SimpleTextAdventure
{
    class Room
    {
        public string Name, Desc;
        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();
        public Room(string n, string d) { Name = n; Desc = d; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foyer = new Room("Foyer", "You are in the foyer. There is a door north.");
            var hall = new Room("Hall", "A grand hall. Doors lead south and east.");
            var kitchen = new Room("Kitchen", "You see a kitchen. Smells good! Door west.");
            foyer.Exits["north"] = hall;
            hall.Exits["south"] = foyer; hall.Exits["east"] = kitchen;
            kitchen.Exits["west"] = hall;
            Room here = foyer;
            while (true)
            {
                Console.WriteLine($"{here.Name}: {here.Desc}");
                Console.Write("Exits: ");
                foreach(var d in here.Exits.Keys) Console.Write(d+" ");
                Console.WriteLine();
                Console.Write("Command: ");
                string cmd = Console.ReadLine().Trim().ToLower();
                if (here.Exits.ContainsKey(cmd)) here = here.Exits[cmd];
                else if (cmd == "quit") break;
                else Console.WriteLine("Can't go that way.");
            }
        }
    }
}