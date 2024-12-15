namespace DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;

public class PlainTextFormatter(INotifier wrappee) : NotificationBaseDecorator(wrappee)
{
    public override void Send(string message)
    {
        string formattedMessage = $"Plain Text: {message}";
        base.Send(formattedMessage);
    }
}
