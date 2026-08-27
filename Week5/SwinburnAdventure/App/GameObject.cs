using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        protected string _description;

        private string _name;

        public GameObject(string[] ids, string name, string desc):base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get {return Name;}
        }
        public string ShortDescription
        {
            get {return _name + " (" + FirstID + ")";}
        }

        public virtual string LongDescription
        {
            get  {return _description;}
        }

    }
}