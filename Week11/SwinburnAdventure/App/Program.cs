using System;
using System.ComponentModel;

namespace SwinburneAdventureWk11
{
public class Program{
    public static void Main(string[] args)
    {
        Player _userPlayer; 
        Console.WriteLine("Welcome, Enter a Player name [First name]");
        string name = Console.ReadLine();
        Console.WriteLine("Enter a description for your player");
        string desc = Console.ReadLine();
        _userPlayer = new Player(name, desc);
        Location _atc;
        Location _en;
        _atc = new Location(new string[] {"atc", "building"}, "ATC", "Advanced Technology Centre building");
        _en = new Location(new string[] {"en", "building"}, "EN", "I believe this is the Engineering building");
        
        Path _atcToEnPath;
        _atcToEnPath = new Path(new string[] {"Path", "atc to en", "south"}, "South", "A Path to EN building (south)", _en);
        Path _enToAtcPath;
        _enToAtcPath = new Path(new string[] {"Path", "en to atc", "north"}, "North", "A Path to ATC building (north)", _atc);

        List<IHaveInventory> myContainers = new List<IHaveInventory>();
        Player _testPlayer;
        _testPlayer = new Player("James", "Explorer");

        myContainers.Add(_userPlayer);


        Bag _testToolBag;


        _testToolBag = new Bag(new string[] {"bag", "tool", "workshop"}, "Tool Bag", "A bag that contains tools");

        
        Item _testItem1;
        Item _testItem2;
        Item _testItem3;
        Item _rat;
    
        _testItem1 = new Item (new string[] {"Tool", "Hammer"}, "hammer", "a hammer for hitting in nails and fixing things");
        _testToolBag.Inventory.Put(_testItem1);

        _testItem2 = new Item (new string[] {"Stew", "beef"}, "Beef Stew", "A hearty beef stew");
        _testToolBag.Inventory.Put(_testItem2);

        _testItem3 = new Item (new string[] {"Potion", "Health"}, "Health Potion", "A health potion that adds 10hp");
        _userPlayer.Inventory.Put(_testItem3);
        _userPlayer.Inventory.Put(_testToolBag);

        _rat = new Item (new string[] {"rat"}, "A rat", "I wouldn't reccomend eating this one...");
        _atc.Inventory.Put(_rat);
        _userPlayer.Location = _atc;
        _atc.Connected(_atcToEnPath);
        _en.Connected(_enToAtcPath);

        foreach(IHaveInventory container in myContainers)
            {
                if(container is Bag)
                {
                    Bag a = (Bag)container;
                    Console.WriteLine(a.FullDescription);
                    Console.WriteLine(a.IdentCount);
                    Console.WriteLine("------------");
                }
                if(container is Player)
                {
                    Player b = (Player)container;
                    Console.WriteLine(b.FullDescription);
                    Console.WriteLine(b.IdentCount);
                    Console.WriteLine("------------");
                }
                if(container is Location)
                {
                    Location b = (Location)container;
                    Console.WriteLine(b.FullDescription);
                    Console.WriteLine("------------");
                }
            }

            bool finished = false;
            LookCommand cmd = new LookCommand([]);
            MoveCommand moveCmd = new MoveCommand([]);
            while(!finished)
            {
                Console.WriteLine("Enter a Command");
                string command = Console.ReadLine();

                if (command.ToLower() =="exit")
                {
                    finished =true;
                    break;
                }
                string[] split = command.Split(" ");
                string firstWord = split[0].ToLower();
                if (firstWord == "look")
                {
                    Console.WriteLine(cmd.Execute(_userPlayer, split));
                }
                if (firstWord == "move" || firstWord == "go" || firstWord == "head" || firstWord == "leave")
                {
                    Console.WriteLine(moveCmd.Execute(_userPlayer, split));
                }
                if (firstWord == "where")
                {
                    Console.WriteLine("You are now at " + _userPlayer.Location.ShortDescription);
                }

            }
        
        //StreamWriter writer = new StreamWriter("TestPlayer.txt");
        //   try
        //    {
        //        _testPlayer.SaveObject(writer);
        //    }
        //    finally
        //    {
        //        writer.Close();
        //    }
        //StreamReader reader = new StreamReader("TestPlayer.txt");
        //    try
        //    {
        //        _testPlayer.LoadFrom(reader);
        //    }
        //    finally
        //    {
        //        writer.Close();
        //    }
    }




}
}
