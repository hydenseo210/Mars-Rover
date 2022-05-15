namespace marsrover;
public class MoveAction
{
    Planet _planet;
    Rover _vehicle;
    Location _locationOfVehicle;

    public MoveAction(Planet planet, Rover vehicle)
    {
        _planet = planet;
        _vehicle = vehicle;
        _locationOfVehicle = _planet.GetLocationOfObject(vehicle);

    }

    public void MoveVehicleOnPlanet(char move)
    {
        switch (move)
        {
            case 'f':
                switch (_vehicle._currentDirection)
                            {
                                case 'N':
                                    if (_vehicle.CollisionDetectedAt(Up()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleUp(_vehicle);
                                    }
                                    break;
                                case 'S':
                                    if (_vehicle.CollisionDetectedAt(Down()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleDown(_vehicle);
                                    }
                                    break;
                                case 'E':
                                    if (_vehicle.CollisionDetectedAt(Left()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleRight(_vehicle);
                                    }
                                    break;
                                case 'W':
                                    if (_vehicle.CollisionDetectedAt(Right()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleLeft(_vehicle);
                                    }
                                    break;
                                default:
                                    break;
                            }
                break;
            default:
                break;

            case 'b':
                switch (_vehicle._currentDirection)
                            {
                                case 'N':
                                    if (_vehicle.CollisionDetectedAt(Down()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleDown(_vehicle);
                                    }
                                    break;
                                case 'S':
                                    if (_vehicle.CollisionDetectedAt(Down()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleUp(_vehicle);
                                    }
                                    break;
                                case 'E':
                                    if (_vehicle.CollisionDetectedAt(Left()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleLeft(_vehicle);
                                    }
                                    break;
                                case 'W':
                                    if (_vehicle.CollisionDetectedAt(Right()))
                                    {
                                    }
                                    else 
                                    {
                                        _planet.MoveVehicleRight(_vehicle);
                                    }
                                    break;
                                default:
                                    break;
                            }
                break;
        }
            
    }
    public Location Up()
    {
        return _planet.at(_locationOfVehicle._x - 1, _locationOfVehicle._y);
    }

    public Location Down()
    {
        return _planet.at(_locationOfVehicle._x + 1, _locationOfVehicle._y);
    }

    public Location Left()
    {
        return _planet.at(_locationOfVehicle._x, _locationOfVehicle._y + 1);
    }
    public Location Right()
    {
        return _planet.at(_locationOfVehicle._x, _locationOfVehicle._y - 1);
    }
}