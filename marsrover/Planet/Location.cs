using System.Security.AccessControl;
namespace marsrover;
public class Location : IPrintable
{
    private Planet _planet;
    private Ground _ground = new Ground();
    public int _x { get; private set;}
    public int _y { get; private set;}

    public Location(Planet planet, int x, int y){
        _planet = planet;
        _x = x;
        _y = y;
    }

    public Planet planet(){
        return _planet;
    }

    public void AddObject(IPrintable Object) 
    {
		_planet.AddObject(Object, this);
	}
    public bool ContainsAObject()
    {
        return _planet.IsObjectAt(this);
    }

    public IPrintable GetObject()
    {
        return _planet.GetObjectAt(this);
    }

    public char GetDisplayChar() 
    {
		IPrintable thing;
		
		if(ContainsAObject()) 
			thing = GetObject();
		else
			thing = _ground;
		
		return thing.GetDisplayChar();
	}
}