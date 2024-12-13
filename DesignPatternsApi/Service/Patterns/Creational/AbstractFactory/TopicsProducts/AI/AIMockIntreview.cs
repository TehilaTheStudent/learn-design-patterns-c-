using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.AI;

public class AIMockInterview : IMockInterview
{
    public string DisplayInterviewStructure()
    {
        return "Interview Structure: 1. Conceptual Questions on ML, 2. Coding Task, 3. Optimization Scenarios.";
    }

    public string ConductInterview()
    {
        return "Score: 90/100 - Strong ML knowledge, but improve understanding of optimization techniques.";
    }

    public string RecommendImprovements()
    {
        return "Focus on advanced topics like gradient descent and deployment of ML models.";
    }
}

