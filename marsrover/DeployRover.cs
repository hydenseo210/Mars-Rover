namespace marsrover;
public class DeployRover
{
    public int[] GetStartingPoint(){
        return new int[]{1,2};
    }

    public char GetStartingDirection(){
        Random random = new Random();
        int randomIndex = random.Next(4);
        List<char> directionList = new List<char>{'N','S','E','W'};
        return directionList[randomIndex];

    }
}
