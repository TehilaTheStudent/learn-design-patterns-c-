using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;
using DesignPatternsApi.Patterns.Creational.FactoryMethod;
using DesignPatternsApi.Patterns.Creational.FactoryMethod.Creators;

namespace DesignPatternsApi.Controllers.Creational;

[ApiController]
[Route("creational/factorymethod")]
public class FactoryMethodController(IApplicationLogger logger, IAmqpQueue deliveryQueue) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;
    private readonly IAmqpQueue _deliveryQueue = deliveryQueue;

    /// <summary>
    /// Endpoint to create a delivery based on the given delivery type.
    /// </summary>
    /// <param name="request">The request body containing the delivery type.</param>
    /// <returns>Success or error message.</returns>
    [HttpPost("deliver")]
    public IActionResult DeliverMaterial([FromBody] DeliveryRequest request)
    {
        try
        {
            // Build the appropriate delivery creator
            var deliveryCreator = BuildDeliveryCreator(request.DeliveryType, _deliveryQueue);

            // Queue the delivery
            deliveryCreator.QueueVehicleForDelivery();

            return Ok(new
            {
                message = $"Delivery successfully queued for {request.DeliveryType}!"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing delivery: {ex.Message}");
            return StatusCode(500, new { message = "An error occurred while processing the delivery." });
        }
    }

    /// <summary>
    /// Factory method to create the appropriate DeliveryCreator instance.
    /// </summary>
    /// <param name="deliveryType">The type of delivery.</param>
    /// <param name="deliveryQueue">The delivery queue.</param>
    /// <returns>The appropriate DeliveryCreator instance.</returns>
    private DeliveryCreator BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue)
    {
        var validDeliveryOptions = new List<string> { "email", "cloud", "link" };
        if (!validDeliveryOptions.Contains(deliveryType))
        {
            throw new InvalidOperationException("Invalid delivery type. Please provide one of the following: [email, cloud, link]");
        }

        return deliveryType switch
        {
            "link" => new LinkDeliveryCreator(deliveryQueue, _logger),
            "email" => new EmailDeliveryCreator(deliveryQueue, _logger),
            "cloud" => new CloudDeliveryCreator(deliveryQueue, _logger),
            _ => throw new InvalidOperationException("Invalid delivery type.")
        };
    }
}

/// <summary>
/// Request body model for the deliver endpoint.
/// </summary>
public class DeliveryRequest
{
    public required string DeliveryType { get; set; }
}