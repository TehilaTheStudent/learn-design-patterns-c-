namespace DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;

public class JsonFormatter(INotifier wrappee) : NotificationBaseDecorator(wrappee)
{
    public override void Send(string message)
    {
        string formattedMessage = $"{{ \"message\": \"{message}\" }}";
        base.Send(formattedMessage);
    }
}
