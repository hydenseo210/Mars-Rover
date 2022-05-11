namespace marsrover
{
    public class ConsoleUI : IConsole
    {
        public string Read(){
            return Console.ReadLine();
        }
        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        public void Print(IPrintable printable)
        {
            Console.Write(printable.GetDisplayChar());
        }
        public void EndLine() 
        {
            Console.WriteLine("");
        }
    }
}

