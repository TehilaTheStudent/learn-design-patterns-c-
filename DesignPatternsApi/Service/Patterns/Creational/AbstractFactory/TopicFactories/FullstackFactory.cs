using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;
using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Fullstack;
using RealisticDependencies;


namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicFactories;
public class FullstackFactory(IApplicationLogger logger) : ITopicFactory
{
    private readonly IApplicationLogger _logger = logger;

    public ICourse CreateCourse()
    {
        _logger.LogInfo("== 🌐 Creating Fullstack Course... ==");
        return new FullstackCourse();
    }

    public IProject CreateProject()
    {
        _logger.LogInfo("== 🌐 Creating Fullstack Project... ==");
        return new FullstackProject();
    }

    public IMockInterview CreateMockInterview()
    {
        _logger.LogInfo("== 🌐 Creating Fullstack Mock Interview... ==");
        return new FullstackMockInterview();
    }
}

