namespace marsrover;
public class TurningSensor
{
    Dictionary<char, char> _directionMappingRight = new Dictionary<char, char>{['N'] = 'E', ['E'] = 'S', ['S'] = 'W', ['W'] = 'N'};
    Dictionary<char, char> _directionMappingLeft = new Dictionary<char, char>{['N'] = 'W', ['W'] = 'S', ['S'] = 'E', ['E'] = 'N'};
    public TurningSensor()
    {
    }
    public char CheckMovement(char currentDirection, char command)
    {
        if (IsRightOf(currentDirection, command)) return 'r';
        if (IsLeftOf(currentDirection, command)) return 'l';
        return 'h';
    }

    public bool IsLeftOf(char direction, char comparedDirection)
    {
        if (_directionMappingLeft[direction] == comparedDirection)
        {
            return true;
        }
        return false;
    }

    public bool IsRightOf(char direction, char comparedDirection)
    {
        if (_directionMappingRight[direction] == comparedDirection)
        {
            return true;
        }
        return false;
    }

}
