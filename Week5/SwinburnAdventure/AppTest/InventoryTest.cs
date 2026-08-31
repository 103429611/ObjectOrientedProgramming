using NUnit.Framework.Internal.Execution;

using SwinburneAdventureWk5;
namespace SwinburneAdventureWk5
{
    public class InventoryTest
    {

        public Inventory inventory;

        private Item item1; 
        private Item item2;
        
        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            item1 = new Item(new string[] { "item1", "first item" }, "Item 1", "This is the first item.");
            item2 = new Item(new string[] { "item2", "second item" }, "Item 2", "This is the second item.");
            inventory.Put(item1);
            inventory.Put(item2);
        }

        [Test]
        public void TestFindItem()
        {
        Assert.That(inventory.HasItem("item1"), Is.True);
        }

        [Test]
        public void TestNotFindItem()
        {
        Assert.That(inventory.HasItem("item3"), Is.False);

        }

        [Test]
        public void TestFetchItem()
        {
            Item item = inventory.Fetch("item1");
            Assert.That(item.AreYou("item1"), Is.True);
            Assert.That(inventory.HasItem("item1"), Is.True);    }

        [Test]
        public void TestTakeItem()
        {
            Assert.That(inventory.HasItem("item1"), Is.True);
            inventory.Take("item1");
            Assert.That(inventory.HasItem("item1"), Is.False);
        }
        [Test]
        public void TestItemList()
        {
            string result = inventory.ItemList;
            Assert.That(result, Is.EqualTo("Item 1 (item1)\nItem 2 (item2)\n"));    
        }
            
        [Test]
        public void LastItemTest()
        {
        Assert.That(inventory.LastItem(), Is.EqualTo(item2));
        inventory.Remove(item1);
        inventory.Remove(item2);
        Assert.That(inventory.LastItem(), Is.EqualTo(null));
        }
    }
}