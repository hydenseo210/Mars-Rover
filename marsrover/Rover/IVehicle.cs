namespace marsrover;
public interface IVehicle : IPrintable
{
    public void ChangeDirection(char NewDirection);
    public char Action(char Command);

}