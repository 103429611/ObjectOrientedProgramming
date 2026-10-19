using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventureWk11
{

    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids )
        {
            
        }
        public abstract string Execute(Player p, string[] text);
    }
}
