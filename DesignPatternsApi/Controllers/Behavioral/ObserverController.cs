using DesignPatternsApi.Service.Patterns.Behavioral.Observer;
using DesignPatternsApi.Service.Patterns.Behavioral.Observer.Observers;
using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;

namespace DesignPatternsApi.Controllers.Behavioral;

[ApiController]
[Route("behavioral/observer")]
public class ObserverController(IApplicationLogger logger) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;

    // Shared instance of the Subject
    private static readonly Subject _subject = new(new ConsoleLogger());

    /// <summary>
    /// Attaches an observer to the subject to receive notifications.
    /// </summary>
    [HttpPost("attach")]
    public IActionResult AttachObserver([FromQuery] string observerType)
    {
        IObserver? observer = observerType.ToLower() switch
        {
            "inapp" => new InAppNotifier(_logger),
            "email" => new EmailNotifier(_logger),
            _ => null
        };

        if (observer == null)
        {
            return BadRequest(new { message = $"Unsupported observer type: {observerType}" });
        }

        _subject.Attach(observer);
        _logger.LogInfo($"Observer of type '{observerType}' attached.");
        return Ok(new { message = $"Observer '{observerType}' successfully attached." });
    }

    /// <summary>
    /// Detaches an observer from the subject.
    /// </summary>
    [HttpPost("detach")]
    public IActionResult DetachObserver([FromQuery] string observerType)
    {
        var observer = _subject.GetObservers().FirstOrDefault(o => o.GetType().Name.ToLower().Contains(observerType.ToLower()));

        if (observer == null)
        {
            return NotFound(new { message = $"Observer of type '{observerType}' not found." });
        }

        _subject.Detach(observer);
        _logger.LogInfo($"Observer of type '{observerType}' detached.");
        return Ok(new { message = $"Observer '{observerType}' successfully detached." });
    }

    /// <summary>
    /// Updates the subject's state and notifies all attached observers.
    /// </summary>
    [HttpPost("update-state")]
    public IActionResult UpdateState()
    {
        _subject.UpdateEmailAddress();
        return Ok(new { message = "State updated and all observers notified." });
    }

    /// <summary>
    /// Retrieves the current state of the subject.
    /// </summary>
    [HttpGet("state")]
    public IActionResult GetState()
    {
        return Ok(new { state = _subject.State });
    }

    /// <summary>
    /// Retrieves the list of attached observers.
    /// </summary>
    [HttpGet("observers")]
    public IActionResult GetObservers()
    {
        var observers = _subject.GetObservers().Select(o => o.GetType().Name).ToList();
        return Ok(new { observers });
    }
}
