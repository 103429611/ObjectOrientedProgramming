using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers ;
        public IdentifiableObject(string[] idents)
        {

            _identifiers = new List<string>();

           // _identifiers = new List<string>(idents);
            foreach (string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
            //_identifiers[0] = "hello";
            //_identifiers[1] = "world";

        }
        public bool AddUniqueId(string id)
        {
            if (_identifiers.Contains(id.ToLower()))
            {
                return false;
            }   
            else
            {
                _identifiers.Add(id.ToLower());
                return true;        
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }
  
        public string FirstID
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        public void PrivilgeEscalation(string pin)
        {
            if (pin == "9611") // the last 4 digits of your ID
            {
                _identifiers[0] = "Class Thursday morning";
            }
        }

    }
}