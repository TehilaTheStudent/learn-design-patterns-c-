namespace DesignPatternsApi.Service.Patterns.Creational.FactoryMethod;

public interface IDeliversMaterial
{
    Task Deliver(int orderId);
}

