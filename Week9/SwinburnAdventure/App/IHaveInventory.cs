using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventureWk9
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);
        string Name {get;}
    }
}
