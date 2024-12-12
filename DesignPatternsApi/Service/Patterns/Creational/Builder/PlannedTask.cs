namespace DesignPatternsApi.Service.Patterns.Creational.Builder;
public class PlannedTask
{
    public required string Id { get; set; }
    public DateTime CreatedOn { get; set; }

    // Generic naming for the context of the task
    public required string TaskName { get; set; }
    public required string TaskDescription { get; set; }

    // Instead of RequestDate or DueDate, just a generic target date
    public DateTime TargetDate { get; set; }

    // The person responsible for this task
    public Models.Assignee Owner { get; set; }

    // A collection of subtasks (similar to line items in a purchase order)
    public required IEnumerable<Models.SubTask> SubTasks { get; set; }

    // Total effort aggregated from all subtasks
    public int TotalEstimatedEffort => SubTasks?.Select(st => st.EstimatedEffortHours).Sum() ?? 0;
}

