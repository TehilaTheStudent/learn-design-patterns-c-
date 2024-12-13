using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Fullstack;
public class FullstackCourse : ICourse
{
    public string DisplaySyllabus()
    {
        return "Syllabus: 1. Front-End Development, 2. Back-End APIs, 3. Database Integration, 4. Full-Stack Project.";
    }

    public string GetProgressReport(string studentId)
    {
        return $"Progress for {studentId}: 50% complete, focus on database integration next.";
    }
}