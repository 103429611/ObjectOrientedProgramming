using System.ComponentModel;

namespace SwinburneAdventureWk9
{
public class Program{
    public static void Main(string[] args)
    {
        List<IHaveInventory> myContainers = new List<IHaveInventory>();
        Player _testPlayer;
        Player _testPlayer2;
        _testPlayer = new Player("James", "Explorer");
        _testPlayer2 = new Player("Ashley", "Lost Traveler");

        myContainers.Add(_testPlayer);
        myContainers.Add(_testPlayer2);

        Bag _testToolBag;
        Bag _testFoodBag;
        Bag _testPotionBag;
        Bag _testKeyBag;
        Bag _testMapBag;

        _testToolBag = new Bag(new string[] {"bag", "tool", "workshop"}, "Tool Bag", "A bag that contains tools");
        _testFoodBag = new Bag(new string[] {"bag", "Food"}, "Food Bag", "A bag that contains all your food");
        _testPotionBag = new Bag(new string[] {"bag", "Potion"}, "Potion Bag", "A bag that contains health potions");
        _testKeyBag = new Bag(new string[] {"bag", "Key"}, "Key Bag", "A bag that contains keys to unlock doors");
        _testMapBag = new Bag(new string[] {"bag", "Map", "waypoints"}, "Map Bag", "A bag that contains maps for areas uncovered");
        
        Item _testItem1;
        Item _testItem2;
        Item _testItem3;
        Item _testItem4;
        Item _testItem5;
        Item _testItem6;
    
        _testItem1 = new Item (new string[] {"Tool", "Hammer"}, "hammer", "a hammer for hitting in nails and fixing things");
        _testToolBag.Inventory.Put(_testItem1);

        _testItem2 = new Item (new string[] {"Stew", "beef"}, "Beef Stew", "A hearty beef stew");
        _testFoodBag.Inventory.Put(_testItem2);

        _testItem3 = new Item (new string[] {"Potion", "Health"}, "Health Potion", "Adds 10hp");
        _testPotionBag.Inventory.Put(_testItem3);

        _testItem4 = new Item (new string[] {"Key", "House"}, "House Key", "Key that unlocks your home");
        _testKeyBag.Inventory.Put(_testItem4);

        _testItem5 = new Item (new string[] {"Map", "Home"}, "Home Map", "Map of your starting locaiton");
        _testMapBag.Inventory.Put(_testItem5);

        _testItem6 = new Item (new string[] {"Stew", "Potato"}, "Potato Stew", "A hearty potato stew");
        _testFoodBag.Inventory.Put(_testItem6);   
            
        myContainers.Add(_testToolBag);
        myContainers.Add(_testFoodBag);
        myContainers.Add(_testPotionBag);
        myContainers.Add(_testKeyBag);
        myContainers.Add(_testMapBag);
        
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
