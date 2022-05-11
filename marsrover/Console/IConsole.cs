namespace marsrover;
public interface IConsole
{  
    string Read();
    void Write(string output);
    void Print(IPrintable printable);
    void EndLine();
}
