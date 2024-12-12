using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;
using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod;
using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.Creators;

namespace DesignPatternsApi.Controllers.Creational;

[ApiController]
[Route("creational/factorymethod")]
public class FactoryMethodController(IApplicationLogger logger, IAmqpQueue deliveryQueue) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;
    private readonly IAmqpQueue _deliveryQueue = deliveryQueue;

    /// <summary>
    /// This example uses the Factory Method creational pattern to help fulfill a Food Delivery order
    /// by bicycle or car depending on the input given to the console application.
    /// One of the benefits of this pattern is that it's easier to extend the delivery type construction
    /// code independently from the Main service method here which invokes it. We could introduce new delivery types
    /// into the project without modifying / breaking our client code - in this case, the Main method.
    /// We've separated the concerns of creating a DeliveryCreator from the client code that uses it.
    /// All of the static data could be extracted from the code into the environment or another configuration source.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [HttpPost("deliver")]
    public IActionResult DeliverMaterial([FromBody] DeliveryRequest request)
    {// Collect data at runtime which will ultimately determine 
     // the chosen implementation of IDeliversFood
        try
        {
            // The client code here deals with business logic at a higher level of abstraction than
            // any of the details related to "how" things actually get delivered.
            // Here we just want to be able to queue up something that delivers food so
            // we can complete our delivery. We can facilitate binding the concrete type as late as possible 
            // by choosing to work with the abstract type here. We don't depend on implementation details - 
            // we depend on abstractions.
            var deliveryCreator = BuildDeliveryCreator(request.DeliveryType, _deliveryQueue);

            // Queue the delivery
            deliveryCreator.QueueDelivererForDelivery();

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
    /// Factory Method invoked by the client (our Main method). This method decides based on data at run-time
    /// which DeliveryCreator type we're eventually binding. Thanks to (dynamic) polymorphism, the
    /// compiler is fine with us declaring the return type of this method as an abstract type,
    /// even though it will return a concrete subclass.
    /// In this case, the decision of which concrete type will eventually be bound is made by evaluating the 
    /// value of a string `deliveryType` provided by the user of our client.
    /// </summary>
    /// <param name="deliveryType"></param>
    /// <param name="deliveryQueue"></param>
    /// <returns></returns>
    private BaseDeliveryCreator BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue)
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