using DesignPatternsApi.Pattern.Creational.FactoryMethod;
using DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;
using RealisticDependencies;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.Creators;

public class CloudDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : DeliveryCreator(deliveryQueue, logger)
{
    /// <summary>
    /// Factory Method for creating a new Cloud (IDeliversMaterial implementation)
    /// </summary>
    /// <returns>Cloud instance</returns>
    protected override IDeliversMaterial RegisterVehicle()
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

