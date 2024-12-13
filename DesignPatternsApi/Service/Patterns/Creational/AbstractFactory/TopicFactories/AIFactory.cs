using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;
using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.AI;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicFactories;
public class AIFactory(IApplicationLogger logger) : ITopicFactory
{
    private readonly IApplicationLogger _logger = logger;

    public ICourse CreateCourse()
    {
        _logger.LogInfo("== 🤖 Creating AI Course... ==");
        return new AICourse();
    }

    public IProject CreateProject()
    {
        _logger.LogInfo("== 🤖 Creating AI Project... ==");
        return new AIProject();
    }

    public IMockInterview CreateMockInterview()
    {
        _logger.LogInfo("== 🤖 Creating AI Mock Interview... ==");
        return new AIMockInterview();
    }

}
