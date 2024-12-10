using DesignPatternsApi.Pattern.Creational.FactoryMethod;
using Newtonsoft.Json;
using RealisticDependencies;

namespace DesignPatternsApi.Patterns.Creational.FactoryMethod
{
    // Creator class.  This class declares the factory method `RegisterVehicle` 
    // that returns an IDeliversMaterial object
    public abstract class DeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger)
    {
        private readonly IAmqpQueue _deliveryQueue = deliveryQueue;
        protected readonly IApplicationLogger _logger = logger;

        // The Factory Method
        // We could provide a default implementation here if we wanted, too!
        protected abstract IDeliversMaterial RegisterVehicle();

        public void QueueVehicleForDelivery()
        {
            var vehicle = RegisterVehicle();
            var vehiclePayload = JsonConvert.SerializeObject(vehicle);
            var queueMessage = new QueueMessage(vehiclePayload);
            _deliveryQueue.Add(queueMessage);
            _logger.LogInfo($"Queued up deliverer of type {vehicle.GetType()} for material delivery.");
        }
    }
}
