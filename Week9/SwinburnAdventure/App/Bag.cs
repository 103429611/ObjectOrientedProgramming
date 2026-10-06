using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventureWk9
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids,name,desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if(AreYou(id))
            {
                return this;
            }
            else if(_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);   
            }
            else
            {
                return null;
            }
        }
        public Inventory Inventory
        {
            get{return _inventory;}
        }
        public override string FullDescription
        {
            get {return "In the " + Name + " you can see:\n" + Inventory.ItemList;}
        }

    }
}