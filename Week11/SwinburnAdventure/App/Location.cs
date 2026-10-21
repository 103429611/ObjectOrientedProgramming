namespace SwinburneAdventureWk11
{
    public class Location: GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths = [];

        public Location(string[] ids, string name, string desc) :base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public Inventory Inventory
        {
            get {return _inventory;}
        }
        public void Connected(Path path)
        {
            _paths.Add(path);
        }
        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            else
            {
                return Inventory.Fetch(id);
            }
        }
        public Path FetchPath(string id)
        {
            foreach(Path p in _paths)
            {
                if(p.AreYou(id))
                {
                    return p;
                }
            }
            return null;
        } 
        public override string FullDescription
        {
            get
            {
                string nameDescription = "";
                string inventoryDescription = "";
                string pathDescription = "";
                if(Name!=null && Name != "")
                {
                    nameDescription = Name;
                }
                else
                {
                    nameDescription= "unknown location description";
                }
                if(_inventory != null && _inventory.ItemList != null)
                {
                    inventoryDescription=_inventory.ItemList;
                }
                else
                {
                    inventoryDescription = "there are no items at this location.";
                }


                for(int i = 0; i < _paths.Count; i++)
                {
                    pathDescription += _paths[i].FullDescription + "\n";
                }
                return "You are in " + nameDescription + "\n" + "Here you can see " + inventoryDescription + " " + pathDescription;

            }
        }
    }
}