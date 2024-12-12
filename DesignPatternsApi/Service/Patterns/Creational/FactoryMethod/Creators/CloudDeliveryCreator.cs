using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.FactoryMethod.Creators;

public class CloudDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : BaseDeliveryCreator(deliveryQueue, logger)
{
    /// <summary>
    /// Factory Method for creating a new Cloud (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Cloud instance</returns>
    protected override IDeliversMaterial RegisterDeliverer()
    {
        var cloud = new Cloud
        {
            StoragePath = "/path/to/storage",
            Provider = "AWS",
            Region = "us-west-1",
            Capacity = 100,
            Type = "SSD"
        };
        _logger.LogInfo("Registering a Cloud to deliver material!", ConsoleColor.Green);
        return cloud;
    }
}

