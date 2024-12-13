using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory;
public interface ITopicFactory
{
    public ICourse CreateCourse();
    public IProject CreateProject();
    public IMockInterview CreateMockInterview();
}

