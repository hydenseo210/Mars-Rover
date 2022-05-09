namespace marsrover;
public class Rover : IVehicle
{
    public char _currentDirection {private get; set;} = 'N';
    IDirections _directions = new Directions();

    public Rover(char CurrentDirection)
    {
        _currentDirection = CurrentDirection;
    }

    public void ChangeDirection(char NewDirection)
    {
        _currentDirection = NewDirection;
    }
    public char GetDisplayChar()
    {
        switch (_currentDirection)
        {
            case 'N':
                return '⍐';
            case 'S':
                return '⍗';
            case 'E':
                return '⍈';
            case 'W':
                return '⍇';
            default:
                return '⍐';
        }
    }
    public char Action(char Command)
    {
        switch (_currentDirection)
        {
            case 'N':
                _currentDirection = _directions.WhenFacingNorth(Command).Item2;
                return _directions.WhenFacingNorth(Command).Item1;
            case 'S':
                _currentDirection = _directions.WhenFacingSouth(Command).Item2;
                return _directions.WhenFacingSouth(Command).Item1;
            case 'E':
                _currentDirection = _directions.WhenFacingEast(Command).Item2;
                return _directions.WhenFacingEast(Command).Item1;
            case 'W':
                _currentDirection = _directions.WhenFacingWest(Command).Item2;
                return _directions.WhenFacingWest(Command).Item1;
            default:
                throw new Exception();
        }
        
    }
}
