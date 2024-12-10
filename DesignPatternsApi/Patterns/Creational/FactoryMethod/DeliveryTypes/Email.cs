
using DesignPatternsApi.Pattern.Creational.FactoryMethod;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod.DeliveryTypes;

public class Email : IDeliversMaterial
{
    public required string RecipientEmail { get; set; } // Email address of the recipient
    public required string SenderEmail { get; set; } // Email address of the sender
    public required string Subject { get; set; } // Subject of the email
    public required string ContentType { get; set; } // Type of email content (e.g., plain text, HTML)

    public async Task Deliver(int materialId)
    {
        // Logic for delivering material via email
        await Task.FromResult($"📧 Delivered Material ID: {materialId} to {RecipientEmail} via email.");
    }
}
