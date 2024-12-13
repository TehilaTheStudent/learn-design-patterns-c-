using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.AI;

public class AICourse : ICourse
{
    public string DisplaySyllabus()
    {
        return "Syllabus: 1. Machine Learning Basics, 2. Neural Networks, 3. Natural Language Processing, 4. Capstone Project.";
    }

    public string GetProgressReport(string studentId)
    {
        return $"Progress for {studentId}: 80% complete, pending the final capstone project.";
    }
}

