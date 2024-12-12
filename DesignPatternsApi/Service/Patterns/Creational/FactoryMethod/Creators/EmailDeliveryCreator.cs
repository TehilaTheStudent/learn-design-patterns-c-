using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.Creators;

public class EmailDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : BaseDeliveryCreator(deliveryQueue, logger)
{
    /// <summary>
    /// Factory Method for creating a new Email (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Email instance</returns>
    protected override IDeliversMaterial RegisterDeliverer()
    {
        var email = new Email
        {
            RecipientEmail = "recipient@example.com",
            SenderEmail = "sender@example.com",
            Subject = "Delivery Notification",
            ContentType = "text/plain"
        };
        _logger.LogInfo("Registering an Email to deliver material!", ConsoleColor.Cyan);
        return email;
    }
}

