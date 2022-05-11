namespace marsrover;
public class CollisionDetectionSensor : ISensor
{
    public bool CheckCollision(Location location)
    {
        Obstacle NewObstacle = new Obstacle();
        char DisplayCharacterOfObstacle = NewObstacle.GetDisplayChar();
        if (location.GetDisplayChar() == DisplayCharacterOfObstacle)
        {
            return true;
        };
        return false;
    }
}
