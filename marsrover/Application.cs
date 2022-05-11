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
        _rover = new Rover(StartingDirection, new Directions(_commands));
        _planet.AddObject(_rover, _planet.at(StartingCoordinates[0], StartingCoordinates[1]));
        AddObstacle(width, height);

    }

    public void Run()
    {
        char[] _arrayOfCommands = _commands.ReturnCommands();
            bool StateOfPlay = true;
            while (Running(StateOfPlay))
            foreach (var command in _arrayOfCommands)
            {
                char CurrentMove = _rover.Action(command);
                Location RoversCurrentLocation = _planet.GetLocationOfObject(_rover);
                int CurrentXCoordinate = RoversCurrentLocation._x;
                int CurrentYCoordinate = RoversCurrentLocation._y;
                switch (CurrentMove)
                {
                    case 'f':
                        switch (_rover._currentDirection)
                        {
                            case 'N':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate - 1, CurrentYCoordinate)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleUp(_rover);
                                }
                                break;
                            case 'S':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate + 1, CurrentYCoordinate)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleDown(_rover);
                                }
                                break;
                            case 'E':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate, CurrentYCoordinate - 1)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleLeft(_rover);
                                }
                                break;
                            case 'W':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate, CurrentYCoordinate + 1)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleRight(_rover);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 'b':
                        switch (_rover._currentDirection)
                        {
                            case 'N':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate + 1, CurrentYCoordinate)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleDown(_rover);
                                }
                                break;
                            case 'S':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate - 1, CurrentYCoordinate)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleUp(_rover);
                                }
                                break;
                            case 'E':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate, CurrentYCoordinate + 1)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleRight(_rover);
                                }
                                break;
                            case 'W':
                                if (_rover.CollisionDetectedAt(_planet.at(CurrentXCoordinate, CurrentYCoordinate - 1)))
                                {
                                    StateOfPlay = false;
                                    _console.Write($"Collision Detected");
                                }
                                else 
                                {
                                    _planet.MoveVehicleLeft(_rover);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
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