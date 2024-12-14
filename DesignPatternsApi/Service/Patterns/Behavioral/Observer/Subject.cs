using RealisticDependencies;
namespace DesignPatternsApi.Service.Patterns.Behavioral.Observer;
public class Subject(IApplicationLogger logger) : ISubject
{
    private readonly IApplicationLogger _logger = logger;
    public ObserverState State { get; set; } = new();

    // Basic list of subscribers
    private readonly List<IObserver> _observers = [];

    // The subscription management methods.
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        _logger.LogInfo("Subject: Attached an observer.");
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        _logger.LogInfo("Subject: Detached an observer.");
    }

    // Trigger an update in each subscriber.
    public void Notify()
    {
        _logger.LogInfo("Subject: notifying all observers");
        foreach (var observer in _observers)
        {
            observer.Update(this);
        }
    }

    public IEnumerable<IObserver> GetObservers()
    {
        return _observers;
    }

    public void UpdateEmailAddress()
    {
        _logger.LogInfo("Updating task status");
        State = new ObserverState
        {
            LastUpdated = DateTime.UtcNow,
            TaskStates = "new status"
        };
        _logger.LogInfo($"Subject: State has just changed: {State}");
        Thread.Sleep(500);
        Notify();
    }
}

