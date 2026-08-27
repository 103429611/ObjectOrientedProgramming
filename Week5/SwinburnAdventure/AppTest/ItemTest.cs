namespace SwinburneAdventure;

public class IdentifiableItemTest
{

    public Item myItem;

    
    [SetUp]
    public void Setup()
    {
        myItem = new Item(new string[] {"Sword"}, "Golden Sword", "A sword made of gold, it's not strong but it's pretty");
    }

    [Test] 
    public void TestAreYou()
    {
        Assert.That(myItem.AreYou("Sword"), Is.True);
    }
    [Test]
    public void TestNotAreYou()
    {
        Assert.That(myItem.AreYou("banana"), Is.False);
    }

    [Test]
    public void TestShortDesc()
    {
        Assert.That(myItem.ShortDescription, Is.EqualTo("Golden Sword sword"));
    }

    [Test]
    public void TestFullDesc()
    {
        Assert.That(myItem.LongDescription, Is.EqualTo("A sword made of gold, it's not strong but it's pretty"));
    }

        [Test]
    public void TestFirstIDWithNoIDs()
    {
        myItem.RemoveIdentifier("Sword");
        Assert.That(myItem.FirstID, Is.EqualTo(""));
    }
    
    [Test]
    public void TestPrivilegeEscalation()
    {
        myItem.PrivilgeEscalation("9611");
       // Assert.That(myPlayer.AreYou("Class Thursday morning"), Is.True);
        Assert.That(myItem.FirstID, Is.EqualTo("Class Thursday morning"));
    }

}
