using RealisticDependencies;
namespace DesignPatternsApi.Service.Patterns.Behavioral.Observer.Observers;

public class InAppNotifier(IApplicationLogger logger) : IObserver
{
    private readonly IApplicationLogger _logger = logger;

    public void Update(ISubject subject)
    {
        _logger.LogInfo("InAppNotifier: Received update from subject.");
    }
}

