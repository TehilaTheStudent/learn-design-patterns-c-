namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;
public interface IProject
{
    // Explains the project goals and requirements
    public string ExplainRequirements();
    // Evaluates the submitted project and provides detailed feedback
    public string EvaluateSubmission(string submission);
    // Provides hints or guidance for completing the project
    public string ProvideResources();
}
