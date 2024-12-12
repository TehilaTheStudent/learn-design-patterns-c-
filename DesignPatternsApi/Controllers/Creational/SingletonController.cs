using DesignPatternsApi.Service.Patterns.Creational.Singleton;
using Microsoft.AspNetCore.Mvc;
using RealisticDependencies;

namespace DesignPatternsApi.Controllers.Creational;

[ApiController]
[Route("creational/singleton")]
public class SingletonController(IApplicationLogger logger) : ControllerBase
{
    private readonly IApplicationLogger _logger = logger;

    /// <summary>
    /// Demonstrates connecting to the task assignment pool from multiple clients.
    /// This mimics the behavior of different regional clients connecting to the database
    /// in the console example.
    /// </summary>
    [HttpPost("connect")]
    public async Task<IActionResult> ConnectToPool([FromBody] TaskConnectionRequest request)
    {
        var clientPool = TaskAssignmentPool.Instance;

        foreach (var client in request.ClientIds)
        {
            await clientPool.AssignTask(client, $"Task-{client}");
        }

        return Ok(new
        {
            message = "Clients successfully connected and tasks assigned.",
            assignedTasks = request.ClientIds
        });
    }

    /// <summary>
    /// Demonstrates disconnecting from the task assignment pool.
    /// This corresponds to releasing connections in the console example.
    /// </summary>
    [HttpPost("disconnect")]
    public async Task<IActionResult> DisconnectFromPool([FromBody] TaskReleaseRequest request)
    {
        var clientPool = TaskAssignmentPool.Instance;

        foreach (var taskId in request.TaskIds)
        {
            await clientPool.ReleaseTask(taskId);
        }

        return Ok(new { message = "Tasks successfully released.", releasedTasks = request.TaskIds });
    }

    /// <summary>
    /// Displays the currently assigned tasks in the pool.
    /// Mimics the console output of the session status in the example.
    /// </summary>
    [HttpGet("assigned-tasks")]
    public IActionResult ShowAssignedTasks()
    {
        var clientPool = TaskAssignmentPool.Instance;
        clientPool.ShowAssignedTasks();
        return Ok(new { message = "Currently assigned tasks are displayed in the logs." });
    }
}

/// <summary>
/// Request model for connecting clients and assigning tasks.
/// </summary>
public class TaskConnectionRequest
{
    /// <summary>
    /// List of client IDs that want to connect to the task assignment pool.
    /// </summary>
    public required List<string> ClientIds { get; set; }
}

/// <summary>
/// Request model for releasing tasks back to the pool.
/// </summary>
public class TaskReleaseRequest
{
    /// <summary>
    /// List of task IDs to release from the pool.
    /// </summary>
    public required List<string> TaskIds { get; set; }
}
