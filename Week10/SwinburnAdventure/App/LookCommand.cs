using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;

namespace SwinburneAdventureWk10
{

    public class LookCommand : Command
    {
        public LookCommand(string[] ids) : base(ids )
        {
            
        }
        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = p;
            if(text.Length == 3 || text.Length == 5)
            {
                if(text[0].ToLower() =="look")
                {
                    if(text[1].ToLower() == "at")
                    {
                        if (text.Length == 5)
                        {
                            if(text[3].ToLower() == "in")
                            {
                                //call the FetchContainer with the current p and text[4] to update the container
                                container = FetchContainer(p, text[4].ToLower());
                                if (container == null)
                                {
                                    return "I cannot find the " + text[4];
                                }
                            }else return "What do you want to look in?";
                        }
                        return LookAtIn(text[2].ToLower(), container);
                    }
                    else return "Unsure what you want to look, try command look at <item>";
                }
            }
            return "Look command has an invalid syntax: try something like 'look at <item> in <container>";
        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            if(obj == null)
            {
                return null;
            }
            else
            {
                IHaveInventory container = obj as IHaveInventory;
                return container;
            }

        }



        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject itm = container.Locate(thingId);
            if (itm == null)
            {
                return "I can't find the " + thingId;
            }
            return itm.FullDescription;
        }
    }
}