namespace marsrover;
public class ObjectLocations
{
  private Dictionary<Location, IPrintable> LocationToObject;
  private Dictionary<IPrintable, Location> ObjectToLocation;

  public ObjectLocations()
  {
    LocationToObject = new Dictionary<Location, IPrintable>();
    ObjectToLocation = new Dictionary<IPrintable, Location>();
  }

  public void Add(IPrintable Object, Location location) 
  {
    if(ObjectToLocation.ContainsKey(Object))
      throw new ArgumentOutOfRangeException();
    if(LocationToObject.ContainsKey(location))
      throw new ArgumentOutOfRangeException();
    
    ObjectToLocation.Add(Object, location);
    LocationToObject.Add(location, Object);
	}
  public void Remove(IPrintable Object) 
  {
		Location location = LocationOf(Object);
		ObjectToLocation.Remove(Object);
		LocationToObject.Remove(location);
	}

  public void Move(IPrintable Object, Location NewLocation)
  {
    Location OldLocation = ObjectToLocation[Object];
    ObjectToLocation[Object] = NewLocation;
    LocationToObject.Remove(OldLocation);
    LocationToObject.Add(NewLocation, Object);
  }

  public bool IsAObjectAt(Location location) 
  {
  return LocationToObject.ContainsKey(location);
  }

  public IPrintable GetObjectAt(Location location) 
  {
		return LocationToObject[location];
	}

  public Location LocationOf(IPrintable Object) 
  {
		return ObjectToLocation[Object];
	}

}