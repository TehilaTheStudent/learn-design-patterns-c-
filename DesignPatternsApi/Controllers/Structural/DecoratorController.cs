using DesignPatternsApi.Service.Patterns.Structural.Decorator;
using DesignPatternsApi.Service.Patterns.Structural.Decorator.ConcreteDecorators;
using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;

namespace DesignPatternsApi.Controllers.Structural;
[ApiController]
[Route("structural/decorator")]
public class DecoratorController : ControllerBase
{
    /// <summary>
    /// Demonstrates the Decorator Pattern by dynamically adding functionalities to a notification sender.
    /// Based on client requests, we can format the message (plain text, HTML, JSON), and optionally
    /// encrypt or compress it. The Decorator Pattern allows us to extend the sender's behavior at runtime
    /// without modifying its core implementation.
    /// </summary>
    /// <returns></returns>
    [HttpPost("notify")]
    public IActionResult SendNotification([FromBody] NotificationRequest request)
    {
        INotifier sender = new BasicNotifier();

        // Apply format decorators based on the request
        if (request.Format == "plain") sender = new PlainTextFormatter(sender);
        if (request.Format == "html") sender = new HtmlFormatter(sender);
        if (request.Format == "json") sender = new JsonFormatter(sender);

        // Apply encryption and compression decorators if requested
        if (request.Encrypt) sender = new Encryption(sender);
        if (request.Compress) sender = new Compression(sender);

        sender.Send(request.Message);
        return Ok(new { Status = "Notification sent" });
    }
}

public class NotificationRequest
{
    public string Message { get; set; }
    public string Format { get; set; } // "plain", "html", "json"
    public bool Encrypt { get; set; }
    public bool Compress { get; set; }
}
