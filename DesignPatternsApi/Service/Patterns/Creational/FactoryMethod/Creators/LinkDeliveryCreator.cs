using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;


namespace DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.Creators;

public class LinkDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : BaseDeliveryCreator(deliveryQueue, logger)
{

    /// <summary>
    /// Factory Method for creating a new Link (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Link instance</returns>
    protected override IDeliversMaterial RegisterDeliverer()
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
