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



        List<IHaveInventory> myContainers = new List<IHaveInventory>();
        Player _testPlayer;
        _testPlayer = new Player("James", "Explorer");

        myContainers.Add(_userPlayer);


        Bag _testToolBag;


        _testToolBag = new Bag(new string[] {"bag", "tool", "workshop"}, "Tool Bag", "A bag that contains tools");

        
        Item _testItem1;
        Item _testItem2;
        Item _testItem3;
    
        _testItem1 = new Item (new string[] {"Tool", "Hammer"}, "hammer", "a hammer for hitting in nails and fixing things");
        _testToolBag.Inventory.Put(_testItem1);

        _testItem2 = new Item (new string[] {"Stew", "beef"}, "Beef Stew", "A hearty beef stew");
        _testToolBag.Inventory.Put(_testItem2);

        _testItem3 = new Item (new string[] {"Potion", "Health"}, "Health Potion", "A health potion that adds 10hp");
        _userPlayer.Inventory.Put(_testItem3);
        _userPlayer.Inventory.Put(_testToolBag);

        
        
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
            }

            bool finished = false;
            LookCommand cmd = new LookCommand([]);
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
                Console.WriteLine(cmd.Execute(_userPlayer, split));

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
