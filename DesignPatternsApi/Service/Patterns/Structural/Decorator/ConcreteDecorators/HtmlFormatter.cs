namespace DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;

public class HtmlFormatter(INotifier wrappee) : NotificationBaseDecorator(wrappee)
{
    public override void Send(string message)
    {
        string formattedMessage = $"<html><body>{message}</body></html>";
        base.Send(formattedMessage);
    }
}
