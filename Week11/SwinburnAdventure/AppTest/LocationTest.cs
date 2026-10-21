namespace SwinburneAdventureWk11
{
    public class LookTest

    {
        private Item _testItem1;
        private Item _testItem2;
        private Player _testPlayer;
        
        [SetUp]

        public void Setup()
        {
            _testPlayer = new Player("James", "an Explorer");
            _testItem1 = new Item(new string []{"silver", "hat"},"A silver hat", "A very shiny silver hat");
            _testItem2 = new Item(new string []{"light", "torch"},"A Torch", "A Torch to light the path");
        
            _testPlayer.Inventory.Put(_testItem1);
            _testPlayer.Inventory.Put(_testItem2);
        }

        [Test]

    }
}