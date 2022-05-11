namespace marsrover;
public class DeployObject : IDeployObject
{
    
    public int[] GetRandomPoint(int width, int height){
        Random random = new Random();
        int randomWidth = random.Next(width);
        int randomHeight = random.Next(height);
        return new int[]{randomWidth, randomHeight};
    }

    public char GetStartingDirection(){
        Random random = new Random();
        int randomIndex = random.Next(4);
        List<char> directionList = new List<char>{'N','S','E','W'};
        return directionList[randomIndex];

    }

}
