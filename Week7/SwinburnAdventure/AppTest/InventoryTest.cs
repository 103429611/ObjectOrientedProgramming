using NUnit.Framework.Internal.Execution;

using SwinburneAdventure;

public class InventoryTest
{

    public Inventory inventory;

    
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
        Item item1 = new Item(new string[] { "item1", "first item" }, "Item 1", "This is the first item.");
        Item item2 = new Item(new string[] { "item2", "second item" }, "Item 2", "This is the second item.");
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
        Console.WriteLine(inventory.ItemList);
    }
}