using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.AI;

public class AIProject : IProject
{
    public string ExplainRequirements()
    {
        return "Requirements: Develop a machine learning model to predict house prices using Python and scikit-learn.";
    }

    public string EvaluateSubmission(string submission)
    {
        if (submission.Contains("scikit-learn") && submission.Contains("model.fit"))
        {
            return "Submission Approved: Well done on implementing a working ML model!";
        }
        return "Submission Rejected: Ensure you use scikit-learn and implement a proper training loop.";
    }

    public string ProvideResources()
    {
        return "Guidance: Start by cleaning your data, then explore features and tune hyperparameters for optimal performance.";
    }
}

