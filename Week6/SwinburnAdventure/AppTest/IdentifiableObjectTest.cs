using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;
using SwinburneAdventure;
namespace SwinburneAdventure;
public class IdentifiableObjectTest
{
 
    public IdentifiableObject myPlayer;

    [SetUp]
    public void Setup()
    {
        myPlayer = new IdentifiableObject(new string[] { "103429611", "Ashley Butler", "Hawthorn" }); 
    }

    [Test] 
    public void TestAreYou()
    {
        Assert.That(myPlayer.AreYou("103429611"), Is.True);
        Assert.That(myPlayer.AreYou("Ashley Butler"), Is.True);
        Assert.That(myPlayer.AreYou("Hawthorn"), Is.True);  
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.That(myPlayer.AreYou("1o3429611"), Is.False);
        Assert.That(myPlayer.AreYou("James Bonds"), Is.False);
        Assert.That(myPlayer.AreYou("Camberwell"), Is.False);
    }

    [Test]
    public void TestCaseSensitive()
    {
      //  Assert.That(myPlayer.AreYou("James Hugh"), Is.True);
        Assert.That(myPlayer.AreYou("ASHLEY BuTlEr"), Is.True);
    }

    [Test]
    public void TestFirstID()
    {
        Assert.That(myPlayer.FirstID, Is.EqualTo("103429611"));
    }

    [Test]
    public void TestFirstIDWithNoIDs()
    {
        myPlayer.RemoveIdentifier("103429611");
        myPlayer.RemoveIdentifier("Ashley Butler");
        myPlayer.RemoveIdentifier("Hawthorn");
        Assert.That(myPlayer.FirstID, Is.EqualTo(""));
    }

    [Test]
    public void TestAddID()
    {
        myPlayer.AddIdentifier("Mary");
        Assert.That(myPlayer.AreYou("Mary"), Is.True);
    }

    [Test]
    public void TestPrivilegeEscalation()
    {
        myPlayer.PrivilgeEscalation("9611");
       // Assert.That(myPlayer.AreYou("Class Thursday morning"), Is.True);
        Assert.That(myPlayer.FirstID, Is.EqualTo("Class Thursday morning"));
    }

    [Test]
    public void TestAddUniqueId()
    {
        Assert.That (myPlayer.AddUniqueId("Hellow"),Is.True);
        Assert.That(myPlayer.AddUniqueId("103429611"),Is.False);
    }
}
