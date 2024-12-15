namespace DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;
public class Compression(INotifier wrappee) : NotificationBaseDecorator(wrappee)
{
    public override void Send(string message)
    {
        string compressedMessage = $"[Compressed] {message}"; // Simulated compression
        base.Send(compressedMessage);
    }
}
