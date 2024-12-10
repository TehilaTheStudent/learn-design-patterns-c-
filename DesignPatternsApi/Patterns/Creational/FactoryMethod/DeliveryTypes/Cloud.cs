using DesignPatternsApi.Pattern.Creational.FactoryMethod;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;

public class Cloud : IDeliversMaterial
{
    public required string StoragePath { get; set; } // Path in cloud storage
    public required string Provider { get; set; } // Name of the cloud provider (e.g., AWS, Azure)
    public required string Region { get; set; } // Cloud region for storage
    public int Capacity { get; set; } // Available capacity in GB
    public required string Type { get; set; } // Storage type (e.g., SSD, HDD)

    public async Task Deliver(int materialId)
    {
        // Logic for delivering material via cloud
        await Task.FromResult($"📧 Delivered Material ID: {materialId} via cloud storage at {StoragePath}.");
    }
}
