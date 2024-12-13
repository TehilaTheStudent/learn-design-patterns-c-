using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;


namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Fullstack;


public class FullstackProject : IProject
{
    public string EvaluateSubmission(string submission)
    {
        if (submission.Contains("RESTful API") && submission.Contains("user authentication"))
        {
            return "Submission meets the requirements.";
        }
        else
        {
            return "Submission does not meet the requirements.";
        }
    }

    public string ExplainRequirements()
    {
        return "Requirements: Build a full-stack web application with user authentication and a CRUD API.";
    }

    public string ProvideResources()
    {
        return "Resources: Focus on implementing a RESTful API and integrating it with a front-end framework.";
    }
}

