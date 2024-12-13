using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory;
using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicFactories;
using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;

namespace DesignPatternsApi.Controllers.Creational;

[ApiController]
[Route("creational/abstract-factory")]
public class AbstractFactoryController(IApplicationLogger logger, ISendsEmails emailer) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;
    private readonly ISendsEmails _emailer = emailer;

    /// <summary>
    /// Accepts a subscriber email and their chosen learning topic to send them a curated learning path.
    /// </summary>
    [HttpPost("learning-path/send")]
    public async Task<IActionResult> SendLearningPath([FromBody] LearningPathRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.SubscriberEmail))
        {
            _logger.LogError("Invalid email provided.");
            return BadRequest(new { message = "Subscriber email is required." });
        }

        // Determine the factory based on the learning topic
        var factory = GetFactoryForTopic(request.Topic);
        if (factory == null)
        {
            _logger.LogError($"Unknown topic: {request.Topic}");
            return BadRequest(new { message = $"Unsupported topic: {request.Topic}" });
        }

        // Create the LearningPathService with the selected factory
        var learningPathService = new LearningPathService(factory, _emailer, _logger);

        try
        {
            await learningPathService.SendLearningPathToSubscriber(request.SubscriberEmail);
            return Ok(new { message = $"Learning path sent successfully to {request.SubscriberEmail}." });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending learning path: {ex.Message}");
            return StatusCode(500, new { message = "An error occurred while sending the learning path." });
        }
    }

    /// <summary>
    /// Retrieves the list of available learning topics.
    /// </summary>
    [HttpGet("learning-path/topics")]
    public IActionResult GetTopics()
    {
        var topics = new List<string> { "AI", "Cloud", "Fullstack" };
        _logger.LogInfo("Fetching list of available topics.");
        return Ok(new { topics });
    }

    /// <summary>
    /// Determines the appropriate factory for a given learning topic.
    /// </summary>
    private ITopicFactory? GetFactoryForTopic(string topic)
    {
        return topic.ToLower() switch
        {
            "ai" => new AIFactory(_logger),
            "cloud" => new CloudFactory(_logger),
            "fullstack" => new FullstackFactory(_logger),
            _ => null
        };
    }
}




/// <summary>
/// Request model for sending a learning path.
/// </summary>
public class LearningPathRequest
{
    /// <summary>
    /// The subscriber's email address.
    /// </summary>
    public required string SubscriberEmail { get; set; }

    /// <summary>
    /// The chosen learning topic (e.g., AI, Cloud, Fullstack).
    /// </summary>
    public required string Topic { get; set; }
}

