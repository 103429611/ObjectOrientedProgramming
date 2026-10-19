namespace SwinburneAdventureWk11
{
    public class Path:GameObject
    {
        private Location _destination;
        public Path(string[] ids, string name, string desc): base(ids, name, desc)
        {
            _destination = dest;
        }
        public Location Destination
        {
            get{return _destination;}
        }
    }
}
