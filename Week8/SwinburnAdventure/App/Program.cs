namespace SwinburneAdventureWk8
{
public class Program{
    public static void Main(string[] args)
    {
        Player _testPlayer = new Player("James", "Explorer");

        Item item1 = new Item(new string []{"silver", "hat"},"A silver hat", "A very shiny silver hat");
        Item item2 = new Item(new string []{"light", "torch"},"A Torch", "A Torch to light the path");
    
        _testPlayer.Inventory.Put(item2);
        _testPlayer.Inventory.Put(item1);

        Console.WriteLine(_testPlayer.AreYou("me"));
        Console.WriteLine(_testPlayer.AreYou("inventory"));

            if (_testPlayer.Locate("torch") != null)
            {
                Console.WriteLine("The object torch exists");
                Console.WriteLine(_testPlayer.Inventory.HasItem("torch"));
            }
            else
            {
                Console.WriteLine("The object torch does not exist");
            }

        StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                _testPlayer.SaveObject(writer);
            }
            finally
            {
                writer.Close();
            }
        StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                writer.Close();
            }
    }




}
}
