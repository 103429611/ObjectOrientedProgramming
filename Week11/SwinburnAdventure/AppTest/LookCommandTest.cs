using System.Reflection;
using SwinburneAdventureWk11;

using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
using System.Data.SqlTypes;
namespace SwinburneAdventureWk11
{
    public class LookCommandTest
    {
        private Item _testItem;
        private Player _testPlayer;
        private Bag _testMoneyBag;
        private LookCommand _testLookCommand;

        [SetUp]
        public void Setup()
        {
            _testLookCommand = new LookCommand(new string[] {""});
            _testPlayer = new Player("Lara", "an adventurer");
            _testItem = new Item(new string[] {"gem", "ruby"}, "a Ruby", "A bright pink ruby");
            _testMoneyBag = new Bag(new string[] {"bag", "money"}, "Money Bag", "A bag that contains valuables");

            _testPlayer.Inventory.Put(_testItem);
        }

        [Test]
        public void TestLookAtMe() //Returns players description when looking at "inventory"
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "inventory"}), Is.EqualTo(_testPlayer.FullDescription));
        }

        [Test]
        public void TestLookAtGem() //Returns the gems description when looking at a gem in the player's inventory.
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem"}), Is.EqualTo(_testItem.FullDescription));
        }

        [Test]
        public void TestLookAtUnknown() //Returns "I can't find the gem" when the the player does not have a gem in their inventory.
        {
            _testPlayer.Inventory.Take("gem");
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem"}), Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestLookAtGemInMe() //Returns the gem's description when looking at a gem in the player's inventory. "look at gem in inventory"
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem", "in", "inventory"}), Is.EqualTo(_testItem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInBag() //Returns the gems description when looking at a gem in a bag that is in the player's inventory
        {
            _testMoneyBag.Inventory.Put(_testItem);
            _testPlayer.Inventory.Put(_testMoneyBag);
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem", "in", "bag"}), Is.EqualTo(_testItem.FullDescription));
        }

        [Test]
        public void TestLookAtGemInNoBag() //Returns "I can't find the bag" when the player does not have a bag in their inventory.
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem", "in", "bag"}), Is.EqualTo("I cannot find the bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag() //Returns "I can't find the gem" when the bag does not have a gem in its inventory
        {
            _testPlayer.Inventory.Put(_testMoneyBag);
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "gem", "in", "bag"}), Is.EqualTo("I can't find the gem"));
        }

        [Test]
        public void TestInvalidLook() //Test look options to check all error conditions. This include “look around”, or “hello your student ID”, “look at your name”.
        {
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "around"}), Is.EqualTo("Look command has an invalid syntax: try something like 'look at <item> in <container>"));
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Hello", "103429611"}), Is.EqualTo("Look command has an invalid syntax: try something like 'look at <item> in <container>"));
            Assert.That(_testLookCommand.Execute(_testPlayer, new string[] {"Look", "at", "your", "name"}), Is.EqualTo("Look command has an invalid syntax: try something like 'look at <item> in <container>"));
        }

    }
}