using System.Reflection;
using SwinburneAdventureWk8;

using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
namespace SwinburneAdventureWk8
{
public class PlayerTest
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
    public void IdentifiablePlayer()
    {
        Assert.That(_testPlayer.AreYou("me"), Is.True);
        Assert.That(_testPlayer.AreYou("inventory"), Is.True);
    }
    [Test]
    public void LocateItems()
    {
        Assert.That(_testPlayer.Inventory.HasItem("silver"), Is.True);
        Assert.That(_testPlayer.Locate("silver"), Is.EqualTo(_testItem1));
    }
    [Test]
    public void LocatePlayer()
    {
        Assert.That(_testPlayer.Locate("me"), Is.EqualTo(_testPlayer));
        Assert.That(_testPlayer.Locate("inventory"), Is.EqualTo(_testPlayer));   
    }
    [Test]
    public void LocateNothing()
    {
        Assert.That(_testPlayer.Locate("banana"), Is.Null);
    }
    [Test]
    public void PlayerFullDescription()
    {
        Assert.That(_testPlayer.FullDescription, Is.EqualTo("You are James an Explorer\nYou are carrying:\nA silver hat (silver),A Torch (light)"));
    }

}
}
