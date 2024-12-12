using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;
using DesignPatternsApi.Service.Patterns.Creational.Builder;
using DesignPatternsApi.Service.Patterns.Creational.Builder.Builders;


namespace DesignPatternsApi.Controllers.Creational;


[ApiController]
[Route("creational/builder")]
public class BuilderController(IApplicationLogger logger, IDatabase database) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;
    private readonly IDatabase _database = database;

    /// <summary>
    /// Demonstrate generating a "Project Task" using the ProjectTaskBuilder and TaskDirector.
    /// This is analogous to using bakery or coffee builders in the console code.
    /// </summary>
    [HttpGet("project-task")]
    public async Task<IActionResult> GenerateProjectTask()
    {
        var builder = new ProjectTaskBuilder();
        var taskDirector = new TaskDirector(_logger, _database);
        await taskDirector.GenerateTask(builder);
        return Ok(new { message = "Project Task generated and saved successfully." });
    }

    /// <summary>
    /// Demonstrate generating a "Learning Task" using the LearningTaskBuilder and TaskDirector.
    /// This parallels the other approach of using a different concrete builder.
    /// </summary>
    [HttpGet("learning-task")]
    public async Task<IActionResult> GenerateLearningTask()
    {
        var builder = new LearningTaskBuilder();
        var taskDirector = new TaskDirector(_logger, _database);
        await taskDirector.GenerateTask(builder);
        return Ok(new { message = "Learning Task generated and saved successfully." });
    }

    /// <summary>
    /// Demonstrate the Fluent Builder for tasks. Instead of passing arguments via console,
    /// we'll accept a JSON body to customize some properties of the WorkTask.
    /// This simulates the custom order creation shown in the console example.
    /// </summary>
    [HttpPost("custom-fluent-task")]
    public async Task<IActionResult> CreateCustomFluentTask([FromBody] FluentTaskRequest request)
    {
        var fluentBuilder = new FluentTaskBuilder()
            .WithId(request.Id)
            .CreatedOn(request.CreatedOn ?? DateTime.UtcNow)
            .Named(request.TaskName)
            .DescribedAs(request.TaskDescription)
            .WithTargetDate(request.TargetDate ?? DateTime.UtcNow.AddDays(2))
            .OwnedBy(new Models.Assignee(
                request.OwnerName ?? "Default Owner",
                request.OwnerEmail ?? "owner@example.com",
                request.OwnerRole ?? "Contributor"
            ))
            .WithSubTasks(request.SubTasks ?? []);

        // Build the task and persist it using the director logic
        var taskDirector = new TaskDirector(_logger, _database);
        var task = fluentBuilder.BuildTask();
        await taskDirector.SaveTaskToDatabase(task);
        // Optionally: Print the task information (just logging here)
        taskDirector.PrintTask(task);

        return Ok(new { message = "Custom Fluent Task created and saved successfully.", task });
    }
}

/// <summary>
/// Request model for creating a custom fluent task.
/// This mirrors the idea of passing parameters at runtime, but now via JSON.
/// </summary>
public class FluentTaskRequest
{
    public required string Id { get; set; }
    public required string TaskName { get; set; }
    public required string TaskDescription { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? TargetDate { get; set; }
    public required string OwnerName { get; set; }
    public required string OwnerEmail { get; set; }
    public required string OwnerRole { get; set; }
    public required List<Models.SubTask> SubTasks { get; set; }
}

