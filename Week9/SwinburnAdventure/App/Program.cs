using System.ComponentModel;

namespace SwinburneAdventureWk9
{
public class Program{
    public static void Main(string[] args)
    {
        List<IHaveInventory> myContainers = new List<IHaveInventory>();
        Player _testPlayer;
        _testPlayer = new Player("James", "Explorer");
        
        myContainers.Add(_testPlayer);

        Bag _testToolBag;
        _testToolBag = new Bag(new string[] {"bag", "tool"}, "Tool Bag", "A bag that contains tools");
        
        Item _testItem2;
        _testItem2 = new Item (new string[] {"Stew", "beef"}, "Beef Stew", "A hearty beef stew");
        _testToolBag.Inventory.Put(_testItem2);
        
        myContainers.Add(_testToolBag);
        
        foreach(IHaveInventory container in myContainers)
            {
                if(container is Bag)
                {
                    Bag a = (Bag)container;
                    Console.WriteLine(a.FullDescription);
                }
                if(container is Player)
                {
                    Player b = (Player)container;
                    Console.WriteLine(b.FullDescription);

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
