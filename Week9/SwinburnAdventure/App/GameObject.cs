using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventureWk9
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
            get {return _name;}
        }
        public string ShortDescription
        {
            get {return _name + " (" + FirstID + ")";}
        }

        public virtual string FullDescription
        {
            get  {return _description;}
        }

        public virtual void SaveObject(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_description);
        }
        public virtual void LoadFrom(StreamReader reader)
        {
            _name = reader.ReadLine();
            _description = reader.ReadLine();
        }
    }
}