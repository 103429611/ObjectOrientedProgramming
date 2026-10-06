using SwinburneAdventureWk9;
using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
namespace SwinburneAdventureWk9
{
    public class BagTest
    {
        private Bag _testToolBag;
        private Bag _testFoodBag;
        private Item _testItem1;
        private Item _testItem2;

        [SetUp]
        public void setup()
        {
        _testToolBag = new Bag(new string [] {"tool bag"}, "toolbag", "a bag to hold your tools");
        _testFoodBag = new Bag(new string [] {"Food bag"}, "foodbag", "a bag to hold your Food");
        _testItem1 = new Item(new string[] { "hammer", "tool" }, "Hammer", "A hammer for hitting or nailing.");
        _testItem2 = new Item(new string[] { "sandwich", "food" }, "Sandwich", "A ham sandwhich, gives 10HP.");
        _testToolBag.Inventory.Put(_testItem1);
        _testFoodBag.Inventory.Put(_testItem2);
        }

        [Test]
        public void BagLocatesItems()
        {
            Assert.That(_testToolBag.Locate("hammer"), Is.EqualTo(_testItem1));
            Assert.That(_testToolBag.Inventory.HasItem("hammer"), Is.True);
            Assert.That(_testFoodBag.Locate("food"), Is.EqualTo(_testItem2));
            Assert.That(_testFoodBag.Inventory.HasItem("food"), Is.True);
        }
        [Test]
        public void BagLocatesItself()
        {
            Assert.That(_testToolBag.Locate("tool bag"), Is.EqualTo(_testToolBag));
            Assert.That(_testFoodBag.Locate("Food bag"), Is.EqualTo(_testFoodBag));
        }

        [Test]
        public void BagLocatesNothing()
        {
            Assert.That(_testToolBag.Locate("Drill"), Is.EqualTo(null));
            Assert.That(_testFoodBag.Locate("Banana"), Is.EqualTo(null));
        }

        [Test]
        public void BagFullDescription()
        {
            Assert.That(_testToolBag.FullDescription, Is.EqualTo("In the toolbag you can see:\nHammer (hammer)"));
        }

        [Test]
        public void BagInBag()
        {
        _testToolBag.Inventory.Put(_testFoodBag);
        Assert.That(_testToolBag.Locate("Food bag"), Is.EqualTo(_testFoodBag));
        Assert.That(_testToolBag.Locate("hammer"), Is.EqualTo(_testItem1));
        Assert.That(_testToolBag.Locate("sandwich"), Is.EqualTo(null));
        }

        [Test]
        public void BagPrevilegedItem()
        {
            _testToolBag.Inventory.Put(_testFoodBag);
            _testItem2.PrivilgeEscalation("9611");
            Assert.That(_testToolBag.Locate("Class Thursday morning"), Is.Null);
        }

    }

}