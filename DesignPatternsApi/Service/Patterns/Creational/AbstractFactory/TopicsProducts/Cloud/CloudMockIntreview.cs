using System;
using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Cloud;

public class CloudMockInterview : IMockInterview
{
    public string DisplayInterviewStructure()
    {
        return "Interview Structure: 1. Cloud Architecture, 2. Hands-on Deployment Task, 3. Cost Optimization Scenarios.";
    }

    public string ConductInterview()
    {
        return "Score: 85/100 - Good knowledge of cloud concepts, but improve on cost optimization strategies.";
    }

    public string RecommendImprovements()
    {
        return "Study best practices for cloud cost management and efficient resource allocation.";
    }
}

