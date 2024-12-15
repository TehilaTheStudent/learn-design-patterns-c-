namespace DesignPatternsApi.Service.Patterns.Structural.Decorator;

public class BasicNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending message: {message}");
    }
}
