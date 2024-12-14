using RealisticDependencies;
namespace DesignPatternsApi.Service.Patterns.Behavioral.Observer.Observers;

public class EmailNotifier(IApplicationLogger logger) : IObserver
{
    private readonly IApplicationLogger _logger = logger;

    public void Update(ISubject subject)
    {
        _logger.LogInfo("EmailNotifier: Received update from subject.");
    }
}

