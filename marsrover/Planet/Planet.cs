using System.Security.AccessControl;
using System.Reflection.Emit;
namespace marsrover;
public class Planet
{
    public int _height {get; private set;}
    public int _width {get; private set;}
    private Location[][] _location;
    private ObjectLocations _objectLocations;

    public Planet(int width, int height)
    {
        _height = height;
        _width = width;
        _location = CreateJaggedArray<Location>(width, height);
        _objectLocations = new ObjectLocations();
        if(_width <= 0 || _height <=0 ) throw new ArgumentOutOfRangeException();
        initialisePlanet(_width, _height, true);

    }

    protected void initialisePlanet(int width, int height, bool wrapping)
    {
        
        for (var _x = 0; _x < _width; _x++)
        {
            for (var y = 0; y < _height; y++)
            {
                _location[_x][y] = MakeNewLocation(_x, y);
            }
        }
    }

    public void AddObjectAtRandomLocation(IDeployObject DeployObject)
    {
        int[] StartingAxis = new int[]{0,0};

        StartingAxis = DeployObject.GetRandomPoint(_height, _width);
        Location NewLocation = at(StartingAxis[0],StartingAxis[1]);
        AddObject(new Obstacle(), NewLocation);
    }
    public void AddObject(IPrintable Object, Location location)
    {
        _objectLocations.Add(Object, location);
    }

    public void RemoveObject(IVehicle vehicle) 
    {
		_objectLocations.Remove(vehicle);
	}

    public void MoveVehicle(IVehicle Vehicle, Location NewLocation)
    {
        if (Vehicle is null) throw new NullReferenceException();
        
        _objectLocations.Move(Vehicle, NewLocation);
    }

    private Location MakeNewLocation(int _x, int y)
    {
        return new Location(this, _x, y);
    }
    
    public bool IsObjectAt (Location location)
    {
        return _objectLocations.IsAObjectAt(location);
    }

    public IPrintable GetObjectAt(Location location) 
    {
		return _objectLocations.GetObjectAt(location);
	}

    public Location GetLocationOfObject(IPrintable Object)
    {
        return _objectLocations.LocationOf(Object);
    }

    public void MoveVehicleUp(IVehicle Vehicle)
    {
        if (Vehicle is null) throw new NullReferenceException();
        Location CurrentLocation = _objectLocations.LocationOf(Vehicle);
        _objectLocations.Move(Vehicle, at(CurrentLocation._x - 1, CurrentLocation._y));
    }

    public void MoveVehicleDown(IVehicle Vehicle)
    {
        if (Vehicle is null) throw new NullReferenceException();
        Location CurrentLocation = _objectLocations.LocationOf(Vehicle);
        _objectLocations.Move(Vehicle, at(CurrentLocation._x + 1, CurrentLocation._y));
    }

    public void MoveVehicleLeft(IVehicle Vehicle)
    {
        if (Vehicle is null) throw new NullReferenceException();
        Location CurrentLocation = _objectLocations.LocationOf(Vehicle);
        _objectLocations.Move(Vehicle, at(CurrentLocation._x, CurrentLocation._y - 1));
    }

    public void MoveVehicleRight(IVehicle Vehicle)
    {
        if (Vehicle is null) throw new NullReferenceException();
        Location CurrentLocation = _objectLocations.LocationOf(Vehicle); 
        _objectLocations.Move(Vehicle, at(CurrentLocation._x, CurrentLocation._y + 1));
    }

    public Location at(int x, int y) 
    {
        int wrappedXCoordinate = CheckWrapping(x, _width); 
        int wrappedYCoordinate = CheckWrapping(y, _height); 
		return _location[wrappedXCoordinate][wrappedYCoordinate];
	}

    public int CheckWrapping(int potentialCoordinate, int boundary)
    {
        if (potentialCoordinate > boundary)
        {
            return 0;
        }
        if (potentialCoordinate < 0)
        {
            return boundary - 1;
        }
        return potentialCoordinate;
    } //unit test

    public void draw(IConsole console)
    {
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                console.Print(this.at(x, y));
            }
            console.EndLine();
        }
        console.Write("\n");
    }

    public static T[][] CreateJaggedArray<T>(int rows, int cols)
    {
        var matrix=new T[rows][];
        for(int i=0; i<rows; i++)
        {
            matrix[i]=new T[cols];
        }
        return matrix;
    }


}

///init position and then final posiiton