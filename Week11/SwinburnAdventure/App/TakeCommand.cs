namespace SwinburneAdventureWk11
{
    public class TakeCommand: Command
    {
        public TakeCommand(string[] ids): base(["take"])
        {
            
        }

        public override string Execute(Player p, string[] text)
        {
            
            if(text.Length != 2)
            {
                return "Take command has the syntax of <take> <item>";
            }
            else
            {
                string _item = text[1].ToLower();
                Item itemToTake = p.Location.Inventory.Take(_item);
                p.Inventory.Put(itemToTake);
                p.Location.Inventory.Remove(itemToTake);
                return "Added " + _item + " to your inventory";
            }    
        }
    }
}