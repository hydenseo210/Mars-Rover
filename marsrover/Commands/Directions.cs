using System.Windows.Input;
namespace marsrover;
public class Directions : IDirections
{
    ICommands _command;
    public Directions(ICommands Command)
    {
        _command = Command;
    }
    public (char,char) WhenFacingNorth(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('f', 'N');
            case 'S':
                return ('b', 'N');
            case 'E':
                return ('r', 'E');
            case 'W':
                return ('l', 'W');
            default:
                throw new Exception();
        }
        
    }
    public (char,char)  WhenFacingSouth(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('b', 'S');
            case 'S':
                return ('f', 'S');
            case 'E':
                return ('l', 'E');
            case 'W':
                return ('r', 'W');
            default:
                throw new Exception();
        }
        
    }
    public (char,char)  WhenFacingEast(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('l', 'N');
            case 'S':
                return ('r', 'S');
            case 'E':
                return ('f', 'E');
            case 'W':
                return ('b', 'E');
            default:
                throw new Exception();
        }
        
    }
    public (char,char)  WhenFacingWest(char Command)
    {
        switch (Command)
        {
            case 'N':
                return ('r', 'N');
            case 'S':
                return ('l', 'S');
            case 'E':
                return ('b', 'W');
            case 'W':
                return ('f', 'W');
            default:
                throw new Exception();
        }
        
    }
}
