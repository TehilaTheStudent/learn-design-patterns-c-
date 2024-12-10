
using DesignPatternsApi.Pattern.Creational.FactoryMethod;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;

public class Link : IDeliversMaterial
{
    public required string Url { get; set; } // The link URL for accessing the material
    public required string Expiration { get; set; } // Expiration date/time for the link
    public required string Description { get; set; } // Description of the material
    public required string AccessType { get; set; } // Public or restricted access

    public async Task Deliver(int materialId)
    {
        // Logic for delivering material via link
        await Task.FromResult($"🔗 Delivered Material ID: {materialId} via link: {Url}");
    }
}
