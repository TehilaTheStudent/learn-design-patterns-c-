namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

public interface IMockInterview
{
    // Provides an overview of the interview structure
    public string DisplayInterviewStructure();
    // Conducts the interview and returns a score/feedback
    public string ConductInterview();
    // Recommends areas for improvement after the interview
    public string RecommendImprovements();
}