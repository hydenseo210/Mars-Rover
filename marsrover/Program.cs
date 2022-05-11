using System.Windows.Input;
using System.Reflection;
namespace marsrover;

public class Program {     
    
    public static void Main(string[] args){
        int width = 10;
        int height = 10;
        ICommands NewCommands = new Commands();
        Application application = new Application(width, height, NewCommands);
        application.Run();
    }
}
