using DesignPatternsApi.Pattern.Creational.FactoryMethod;
using DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.Creators;

public class EmailDeliveryCreator : DeliveryCreator
{
    public EmailDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger) { }
    /// <summary>
    /// Factory Method for creating a new Email (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Email instance</returns>
    protected override IDeliversMaterial RegisterVehicle()
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

