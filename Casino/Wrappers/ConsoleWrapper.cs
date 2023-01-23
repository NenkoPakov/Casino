namespace Casino.Wrappers
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine() => ReadLine();
        public void WriteLine(string message) => WriteLine(message);
        public void Write(string message) => Write(message);
    }
}
