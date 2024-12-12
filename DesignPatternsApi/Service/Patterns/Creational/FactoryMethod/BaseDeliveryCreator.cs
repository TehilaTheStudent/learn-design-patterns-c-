using DesignPatternsApi.Service.Patterns.Creational.FactoryMethod;
using Newtonsoft.Json;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.FactoryMethod;

// Creator class.  This class declares the factory method `Registerdeliverer` 
// that returns an IDeliversMaterial object
public abstract class BaseDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger)
{
    private readonly IAmqpQueue _deliveryQueue = deliveryQueue;
    protected readonly IApplicationLogger _logger = logger;

    // The Factory Method
    // We could provide a default implementation here if we wanted, too!
    protected abstract IDeliversMaterial RegisterDeliverer();

    public void QueueDelivererForDelivery()
    {
        var deliverer = RegisterDeliverer();
        var delivererPayload = JsonConvert.SerializeObject(deliverer);
        var queueMessage = new QueueMessage(delivererPayload);
        _deliveryQueue.Add(queueMessage);
        _logger.LogInfo($"Queued up deliverer of type {deliverer.GetType()} for material delivery.");
    }
}

