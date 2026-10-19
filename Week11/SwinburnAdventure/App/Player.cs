using System.Formats.Asn1;
using System.Globalization;
using System.Net.ServerSentEvents;
using System.Security.Cryptography.X509Certificates;

namespace SwinburneAdventureWk11
{
    public class Player: GameObject, IHaveInventory
    {
        private Inventory _inventory;

        private Location _location;

        public Player(string name, string desc): base(new string [] {"me", "Inventory"}, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location();
        }
        public Inventory Inventory
        {

            get
            {
                return _inventory;
            }
        }
        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            else
            {
                Item obj = _inventory.Fetch(id);
                if(obj == null && Location !=null)
                {
                    return Location.Locate(id);
                }
                return obj;
            }
        }
        public Location Location
        {
            get{return _location;}
            set{_location = value;}
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + _inventory.ItemList;
           }
        }
        public override void SaveObject(StreamWriter writer)
        {
            base.SaveObject(writer);
            writer.WriteLine(_inventory.ItemList);
            writer.WriteLine("Your name is John");
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string ItemDescriptionList = reader.ReadLine();
            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine(ShortDescription);
            Console.WriteLine(ItemDescriptionList);        
        }
    }
}