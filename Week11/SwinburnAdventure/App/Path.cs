namespace SwinburneAdventureWk11
{
    public class Path:GameObject
    {
        public Location _destination;
        public Path(string[] ids, string name, string desc, Location dest): base(ids, name, desc)
        {
            _destination = dest;
        }
        public Location Destination
        {
            get{return _destination;}
        }
    }
}
