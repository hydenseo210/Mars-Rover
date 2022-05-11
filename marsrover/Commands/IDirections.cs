namespace marsrover;
public interface IDirections
{
    public (char,char)  WhenFacingNorth(char Command);
    public (char,char)  WhenFacingSouth(char Command);
    public (char,char)  WhenFacingEast(char Command);
    public (char,char)  WhenFacingWest(char Command);
    
}
