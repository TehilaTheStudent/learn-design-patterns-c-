using DesignPatternsApi.Pattern.Creational.FactoryMethod;
using DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;


namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.Creators;

public class LinkDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : DeliveryCreator(deliveryQueue, logger)
{

    /// <summary>
    /// Factory Method for creating a new Link (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Link instance</returns>
    protected override IDeliversMaterial RegisterVehicle()
    {
        var link = new Link
        {
            Url = "https://example.com/material",
            Expiration = "2023-12-31T23:59:59Z",
            Description = "Sample material description",
            AccessType = "Public",
        };
        _logger.LogInfo("Registering a Link to deliver material!", ConsoleColor.Green);
        return link;
    }

}
