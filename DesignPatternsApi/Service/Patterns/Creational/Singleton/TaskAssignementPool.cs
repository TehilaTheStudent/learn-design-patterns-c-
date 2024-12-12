using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.Singleton;

/// <summary>
/// This class represents a Singleton that manages a pool of task assignments
/// for team members. It ensures:
/// - Thread safety with lazy initialization.
/// - Centralized control over task assignment and release.
/// - Preventing duplicate assignments of the same task.
///
/// This pattern is useful in scenarios where a single shared resource
/// (like a pool of tasks) must be managed in a controlled and efficient way.
/// </summary>
public class TaskAssignmentPool
{
    private readonly IApplicationLogger _logger;
    private readonly Database _database;
    private readonly HashSet<string> _assignedTasks = []; // Tracks assigned tasks.
    private int _openConnections = 0; // Tracks the number of open connections.

    // Use lazy initialization to create a thread-safe singleton instance.
    private static readonly Lazy<TaskAssignmentPool> _instance
        = new(() =>
        {
            var logger = new ConsoleLogger();
            var database = new Database(Configuration.ConnectionString, logger);
            return new TaskAssignmentPool(database, logger);
        });

    /// <summary>
    /// Private constructor to enforce Singleton behavior.
    /// Ensures that the TaskAssignmentPool can only be instantiated once.
    /// </summary>
    private TaskAssignmentPool(Database database, IApplicationLogger logger)
    {
        _database = database;
        _logger = logger;
    }

    /// <summary>
    /// The Singleton instance of the TaskAssignmentPool.
    /// Access this to manage task assignments across the system.
    /// </summary>
    public static TaskAssignmentPool Instance => _instance.Value;

    /// <summary>
    /// Assigns a task to a team member.
    /// - Ensures the task is not already assigned.
    /// - Logs the assignment operation.
    /// - Records the assignment in the database for tracking.
    /// </summary>
    /// <param name="assignee">The name of the team member taking the task.</param>
    /// <param name="taskId">The unique ID of the task.</param>
    public async Task AssignTask(string assignee, string taskId)
    {
        await Connect(assignee);

        if (_assignedTasks.Contains(taskId))
        {
            _logger.LogError($"Task '{taskId}' is already assigned to another team member.");
            await Disconnect();
            return;
        }

        _logger.LogInfo($"Assigning Task '{taskId}' to {assignee}.", ConsoleColor.Green);
        _assignedTasks.Add(taskId);
        await _database.WriteData(taskId, $"Assigned to {assignee} at {DateTime.UtcNow}");

        await Disconnect();
    }

    /// <summary>
    /// Releases a task back to the pool.
    /// - Ensures the task was previously assigned.
    /// - Logs the release operation.
    /// - Records the release in the database for tracking.
    /// </summary>
    /// <param name="taskId">The unique ID of the task to release.</param>
    public async Task ReleaseTask(string taskId)
    {
        await Connect("ReleaseTask");

        if (!_assignedTasks.Contains(taskId))
        {
            _logger.LogInfo($"Task '{taskId}' is not currently assigned.", ConsoleColor.Yellow);
            await Disconnect();
            return;
        }

        _logger.LogInfo($"Releasing Task '{taskId}' back to the pool.", ConsoleColor.Blue);
        _assignedTasks.Remove(taskId);
        await _database.WriteData(taskId, $"Released back to pool at {DateTime.UtcNow}");

        await Disconnect();
    }

    /// <summary>
    /// Displays all currently assigned tasks in the pool.
    /// Useful for monitoring active assignments in the system.
    /// </summary>
    public void ShowAssignedTasks()
    {
        _logger.LogInfo("Currently Assigned Tasks:", ConsoleColor.Cyan);
        foreach (var taskId in _assignedTasks)
        {
            _logger.LogInfo($" - Task: {taskId}", ConsoleColor.Cyan);
        }
    }

    public async Task Connect(string client)
    {
        if (_openConnections >= Configuration.MaxConnections)
        {
            _logger.LogError("ERROR - Cannot acquire new connection. " +
                              $"Max connections of {Configuration.MaxConnections} " +
                              "is met or exceeded.");
            return;
        }

        _openConnections++;
        _logger.LogInfo($"Added connection to pool from: {client}", ConsoleColor.Blue);
        await _database.Connect(client);
    }

    public async Task Disconnect()
    {
        if (_openConnections <= 0)
        {
            _logger.LogInfo("There are no connections to close.", ConsoleColor.Blue);
            return;
        }

        _openConnections--;
        _logger.LogInfo($"Released connection. Now managing ({_openConnections}) open connections.",
            ConsoleColor.Blue);
        await _database.Disconnect();
    }
}

