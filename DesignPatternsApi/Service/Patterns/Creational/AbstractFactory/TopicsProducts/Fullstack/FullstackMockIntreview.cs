using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Fullstack;
public class FullstackMockInterview : IMockInterview
{
    public string DisplayInterviewStructure()
    {
        return "Interview Structure: 1. System Design, 2. API Implementation Task, 3. Debugging Challenge.";
    }

    public string ConductInterview()
    {
        return "Score: 80/100 - Solid technical skills, but work on debugging under time constraints.";
    }

    public string RecommendImprovements()
    {
        return "Practice debugging common API issues and focus on efficient database queries.";
    }
}

