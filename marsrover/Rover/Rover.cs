namespace marsrover;
public class Rover : IVehicle
{
    public char _currentDirection { get; set;} = 'N';
    IDirections _directions;
    CollisionDetectionSensor _collisionDetectionSensor = new CollisionDetectionSensor();
    MovingSensor _movingSensor = new MovingSensor();
    TurningSensor _turningSensor = new TurningSensor();

    public Rover(char CurrentDirection, IDirections Directions)
    {
        _directions = Directions;
        _currentDirection = CurrentDirection;
    }

    public bool CollisionDetectedAt(Location location)
    {
        return _collisionDetectionSensor.CheckCollision(location);
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
    public char Action(char command)
    {
        var movingCommand = _movingSensor.CheckMovement(_currentDirection, command);
        if (movingCommand == 'h')
        {
            return _turningSensor.CheckMovement(_currentDirection, command);
        }
        return movingCommand;
        
    }
    
}
