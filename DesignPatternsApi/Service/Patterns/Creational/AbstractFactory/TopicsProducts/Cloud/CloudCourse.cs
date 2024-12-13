using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Cloud;

public class CloudCourse : ICourse
{
    public string DisplaySyllabus()
    {
        return "Syllabus: 1. Introduction to AWS, 2. Cloud Deployment Models, 3. Load Balancing, 4. Final Deployment Project.";
    }

    public string GetProgressReport(string studentId)
    {
        return $"Progress for {studentId}: 60% complete, keep up the good work!";
    }
}

