namespace DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;

public class Encryption(INotifier wrappee) : NotificationBaseDecorator(wrappee)
{
    public override void Send(string message)
    {
        string encryptedMessage = $"[Encrypted] {message}"; // Simulated encryption
        base.Send(encryptedMessage);
    }
}
