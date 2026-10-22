namespace SwinburneAdventureWk11
{
    public class MoveCommandTest
    {
        private Player _testPlayer;
        private Location _locationOne;
        private Location _locationTwo;
        private Path _pathLocOneToTwo;
        private Path _pathLocTwoToOne;
        private MoveCommand _testMoveCommand;
        private LookCommand _testLookCommand;
        

        [SetUp]
        public void Setup()
        {

            _testPlayer = new Player("Lara", "an adventurer");

            _locationOne = new Location(new string[] {"one"}, "One", "Location one");
            _locationTwo = new Location(new string[] {"two"}, "Two", "Location Two");
            _pathLocOneToTwo = new Path( new string[] {"path", "north"}, "North", "a path from first location to second", _locationTwo);
            _pathLocTwoToOne = new Path( new string[] {"path", "south"}, "South", "a path from Second location to First", _locationOne);
            _locationOne.Connected(_pathLocOneToTwo);
            _locationTwo.Connected(_pathLocTwoToOne);            
            _testPlayer.Location = _locationOne;

            _testMoveCommand = new MoveCommand([]);
            _testLookCommand = new LookCommand([]);
        }
        [Test]
        public void TestMoveToLocation()
        {
            string command = "Move north";
            string[] split = command.Split(" ");
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationOne));
            _testMoveCommand.Execute(_testPlayer,split);
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationTwo));
        }
        [Test]
        public void TestGetPathFromLocation()
        {
            string command = "look";
            string[] split = command.Split(" ");
            Assert.That(_testLookCommand.Execute(_testPlayer,split),Is.EqualTo(_locationOne.FullDescription));
        }
        [Test]
        public void TestGoAndLeaveLocation()
        {
            string command = "Move north";
            string[] split = command.Split(" ");
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationOne));
            Console.WriteLine(_testPlayer.Location.FullDescription);
            _testMoveCommand.Execute(_testPlayer,split);
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationTwo));
            Console.WriteLine(_testPlayer.Location.FullDescription);
            command = "move south";
            split = command.Split(" ");
            _testMoveCommand.Execute(_testPlayer,split);
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationOne));
            Console.WriteLine(_testPlayer.Location.FullDescription);

        }
        [Test]
        public void TestStayInLocationWhenPathInvalid()
        {
            string command = "Move west";
            string[] split = command.Split(" ");
            Assert.That(_testPlayer.Location,Is.EqualTo(_locationOne));
            Assert.That(_testMoveCommand.Execute(_testPlayer,split),Is.EqualTo("the path is not available in that direction"));

        }
    }
}