using Newtonsoft.Json;
using RealisticDependencies;

namespace DesignPatternsApi.Service.Patterns.Creational.Builder;

/// <summary>
/// The "Director" class for WorkTask building.
/// Similar to PurchaseOrderProcessor but for tasks.
/// </summary>
public class TaskDirector(IApplicationLogger logger, IDatabase database)
{
    private readonly IApplicationLogger _logger = logger;
    private readonly IDatabase _database = database;

    public async Task GenerateTask(ITaskBuilder taskBuilder)
    {
        var task = taskBuilder.BuildTask();
        PrintTask(task);
        await SaveTaskToDatabase(task);
    }

    public async Task SaveTaskToDatabase(PlannedTask task)
    {
        _logger.LogInfo($"Saving PlannedTask ({task.Id}) to database");
        await _database.Connect();
        await _database.WriteData(task.Id, JsonConvert.SerializeObject(task));
        await _database.Disconnect();
    }

    public void PrintTask(PlannedTask task)
    {
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Green);
        _logger.LogInfo($"== 📋 Generated PlannedTask", ConsoleColor.Green);
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Green);
        _logger.LogInfo($"== ID: {task.Id} | Created On: {task.CreatedOn}", ConsoleColor.Green);
        _logger.LogInfo($"== PlannedTask: {task.TaskName}", ConsoleColor.Green);
        _logger.LogInfo($"== Description: {task.TaskDescription}", ConsoleColor.Green);
        _logger.LogInfo($"----------------------------------------");
        _logger.LogInfo($"== Owner: {task.Owner.Name} ({task.Owner.Email}, {task.Owner.Role})", ConsoleColor.Green);
        _logger.LogInfo($"== Target Date: {task.TargetDate}", ConsoleColor.Green);
        _logger.LogInfo($"----------------------------------------");
        _logger.LogInfo("== SubTasks:", ConsoleColor.DarkGreen);
        if (task.SubTasks != null)
        {
            foreach (var sub in task.SubTasks)
            {
                _logger.LogInfo($"  - {sub.Name} (Est. Effort: {sub.EstimatedEffortHours} hours)", ConsoleColor.DarkGreen);
            }
        }
        _logger.LogInfo($"== Total Estimated Effort: {task.TotalEstimatedEffort} hours", ConsoleColor.Green);
        _logger.LogInfo($"----------------------------------------", ConsoleColor.Green);
    }
}

