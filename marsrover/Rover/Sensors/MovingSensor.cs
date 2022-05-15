namespace marsrover;
public class MovingSensor
{
    Dictionary<char, char> _directionMappingOpposites = new Dictionary<char, char>{['N'] = 'S', ['S'] = 'N', ['E'] = 'W', ['W'] = 'E'};
    public MovingSensor()
    {
    }
    public char CheckMovement(char currentDirection, char command)
    {
        if (currentDirection == command) return 'f';
        if (IsOpposite(currentDirection, command)) return 'b';
        return 'h';
    }

    public bool IsOpposite(char direction, char comparedDirection)
    {
        if (_directionMappingOpposites[direction] == comparedDirection || _directionMappingOpposites[comparedDirection] == direction)
        {
            return true;
        }
        return false;
    }

} 
