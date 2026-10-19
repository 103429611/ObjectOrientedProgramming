namespace SwinburneAdventureWk11
{
    public class MoveCommand: Command
    {
        public MoveCommand(string[] ids): base(["move", "go", "head", "leave"])
        {
            
        }
        public override string Execute(Player p, string[] text)
        {
            if(text.Length != 2)
            {
                return "Move command has the syntax of <move> <direction>";
            }
            else
            {
                Path selPath = p.Location.FetchPath(text[1].ToLower());
                if(selPath == null)
                {
                    return "the path is not available in that direction";
                }
                else
                {
                    p.Location = selPath._destination;
                    return selPath.FullDescription;
                }
            }
        }
    }
}