

namespace RealisticDependencies;

public class EmailMessage(string to, string content)
{
    public string To { get; set; } = to;
    public string Content { get; set; } = content;
}

public interface ISendsEmails
{
    public Task SendMessage(EmailMessage message);
}

public class Emailer(IApplicationLogger logger) : ISendsEmails
{
    private readonly IApplicationLogger _logger = logger;

    public async Task SendMessage(EmailMessage message)
    {
        await Task.Delay(1000);
        _logger.LogInfo($"Sent email to: {message.To} with Message: {message.Content}", ConsoleColor.Cyan);
    }
}
