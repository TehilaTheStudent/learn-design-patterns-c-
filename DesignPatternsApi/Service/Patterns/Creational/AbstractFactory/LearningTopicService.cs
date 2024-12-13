

using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.AbstractFactory;
public class LearningPathService(
    ITopicFactory factory,
    ISendsEmails emailer,
    IApplicationLogger logger) : ILearningPathService
{
    private readonly ITopicFactory _factory = factory;
    private readonly ISendsEmails _emailer = emailer;
    private readonly IApplicationLogger _logger = logger;

    public async Task SendLearningPathToSubscriber(string subscriberEmail)
    {
        _logger.LogInfo("--------------------------------------------------------------");

        var course = _factory.CreateCourse();
        var project = _factory.CreateProject();
        var mockInterview = _factory.CreateMockInterview();

        _logger.LogInfo($"== 📚 Compiling Course for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
        var courseSyllabus = course.DisplaySyllabus();
        _logger.LogInfo($"Syllabus: {courseSyllabus}", ConsoleColor.Green);

        _logger.LogInfo($"== 🔨 Compiling Project for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
        var projectDetails = project.ExplainRequirements();
        _logger.LogInfo($"Project Details: {projectDetails}", ConsoleColor.Green);

        _logger.LogInfo($"== 🎤 Compiling Mock Interview for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
        var interviewStructure = mockInterview.DisplayInterviewStructure();
        _logger.LogInfo($"Interview Structure: {interviewStructure}", ConsoleColor.Green);

        // Create the email body
        var emailBody = $"Learning Path:\n\nCourse Syllabus:\n{courseSyllabus}\n\n" +
                        $"Project Details:\n{projectDetails}\n\n" +
                        $"Mock Interview Structure:\n{interviewStructure}";
        var message = new EmailMessage(subscriberEmail, emailBody);

        _logger.LogInfo("== ✉️ Sending Subscriber Email ==", ConsoleColor.Cyan);
        await _emailer.SendMessage(message);

        _logger.LogInfo("--------------------------------------------------------------", ConsoleColor.Cyan);
    }
}

public interface ILearningPathService
{
    public Task SendLearningPathToSubscriber(string subscriberEmail);
}

