using DelegatesOtus.Abstractions;

namespace DelegatesOtus;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}