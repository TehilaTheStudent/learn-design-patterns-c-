namespace DesignPatternsApi.Service.Patterns.Structural.Decorator;
public abstract class NotificationBaseDecorator(INotifier wrappee) : INotifier
{
    protected INotifier _wrappee = wrappee;

    public virtual void Send(string message)
    {
        _wrappee.Send(message);
    }
}
