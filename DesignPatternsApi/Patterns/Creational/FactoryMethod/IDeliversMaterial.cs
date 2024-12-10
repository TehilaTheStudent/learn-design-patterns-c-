namespace DesignPatternsApi.Pattern.Creational.FactoryMethod;

public interface IDeliversMaterial
{
    Task Deliver(int orderId);
}

