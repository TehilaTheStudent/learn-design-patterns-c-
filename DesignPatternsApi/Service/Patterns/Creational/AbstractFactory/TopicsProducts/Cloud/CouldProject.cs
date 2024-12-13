using DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.IProducts;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory.TopicsProducts.Cloud;

public class CloudProject : IProject
{
    public string ExplainRequirements()
    {
        return "Requirements: Deploy a web application using AWS services like EC2, S3, and RDS.";
    }

    public string EvaluateSubmission(string submission)
    {
        if (submission.Contains("EC2") && submission.Contains("S3"))
        {
            return "Submission Approved: Excellent use of EC2 and S3!";
        }
        return "Submission Rejected: Make sure you include both EC2 and S3 in your deployment.";
    }

    public string ProvideResources()
    {
        return "Guidance: Start by setting up an EC2 instance, uploading files to S3, and configuring RDS for the database.";
    }
}

