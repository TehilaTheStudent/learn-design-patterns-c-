namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;
public interface ICourse
{
    // Provides a detailed syllabus for the course
    public string DisplaySyllabus();
    // Returns a progress report for a student
    public string GetProgressReport(string studentId);
}




