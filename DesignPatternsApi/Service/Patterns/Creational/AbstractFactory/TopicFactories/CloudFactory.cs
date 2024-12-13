using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;
using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Cloud;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicFactories;
public class CloudFactory(IApplicationLogger logger) : ITopicFactory
{
    private readonly IApplicationLogger _logger = logger;

    public ICourse CreateCourse()
    {
        _logger.LogInfo("== ☁️ Creating Cloud Course... ==");
        return new CloudCourse();
    }

    public IProject CreateProject()
    {
        _logger.LogInfo("== ☁️ Creating Cloud Project... ==");
        return new CloudProject();
    }

    public IMockInterview CreateMockInterview()
    {
        _logger.LogInfo("== ☁️ Creating Cloud Mock Interview... ==");
        return new CloudMockInterview();
    }
}

