using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }
        
        public bool HasItem(string id)
        {
            foreach(Item i in _items)
            {
                if(i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item item)
        {
            _items.Add(item);
        }
        public void Remove(Item item)
        {
            _items.Remove(item);
        }


        public Item Take(string id)
        {
            Item itmremove = null;
            
            foreach (Item item in _items)
            {
                if (itmremove == null && item.AreYou(id.ToLower()))
                {
                    itmremove = item; 
                }
            }
            
            if(itmremove != null)
            {
                _items.Remove(itmremove);
            }
            
            return itmremove;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id.ToLower()))
                {
                    return item;
                }
            }
            return null;
        }
        
        public string ItemList
        {
            get
            {
                string result = String.Empty;
                foreach(Item i in _items)
                {
                    result += i.ShortDescription + "\n";
                }
                return result;
            }
        }

    }   
}