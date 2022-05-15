namespace marsrover;

public class Application
{
    IConsole _console = new ConsoleUI(); 
    IDeployObject _deployObject = new DeployObject();
    ICommands _commands;
    Planet _planet;
    Rover _rover;

    public Application(int width, int height, ICommands commands)
    {
        _commands = commands;
        _planet = new Planet(width, height);
        char StartingDirection = _deployObject.GetStartingDirection();
        int[] StartingCoordinates = _deployObject.GetRandomPoint(width, height);
        _rover = new Rover(StartingDirection, new Directions());
        _planet.AddObject(_rover, _planet.at(StartingCoordinates[0], StartingCoordinates[1]));
        AddObstacle(width, height);

    }

    public void Run()
    {
        char[] _arrayOfCommands = _commands.ReturnCommands();
            bool StateOfPlay = true;
                foreach (var command in _arrayOfCommands)
                {
                    if (!StateOfPlay) break;
                    char CurrentMove = _rover.Action(command);
                    Location RoversCurrentLocation = _planet.GetLocationOfObject(_rover);
                    int CurrentXCoordinate = RoversCurrentLocation._x;
                    int CurrentYCoordinate = RoversCurrentLocation._y;
                    
                _planet.draw(_console);
                }
    }

    public void AddObstacle(int width, int height)
    {
        int totalNumberOfObstacles = 3;
        for (var i = 0; i < totalNumberOfObstacles; i++)
        {
            int[] StartingCoordinates = _deployObject.GetRandomPoint(width, height);
            _planet.AddObject(new Obstacle(), _planet.at(StartingCoordinates[0], StartingCoordinates[1]));
        }
    }
    public bool Running(bool StateOfPlay)
    {
        return StateOfPlay;
    }
}