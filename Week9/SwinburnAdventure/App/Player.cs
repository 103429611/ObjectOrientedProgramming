using System.Formats.Asn1;
using System.Globalization;

namespace SwinburneAdventureWk9
{
    public class Player: GameObject, IHaveInventory
    {
        private Inventory _inventory;

        public Player(string name, string desc): base(new string [] {"me", "Inventory"}, name, desc)
        {
            _inventory = new Inventory();
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
                return _inventory.Fetch(id);
            }
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