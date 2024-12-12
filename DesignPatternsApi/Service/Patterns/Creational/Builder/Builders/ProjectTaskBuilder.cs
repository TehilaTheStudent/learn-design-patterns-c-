namespace DesignPatternsApi.Service.Patterns.Creational.Builder.Builders;
public class ProjectTaskBuilder : ITaskBuilder
{
    private string _id;
    private DateTime _createdOn;
    private string _taskName;
    private string _taskDescription;
    private DateTime _targetDate;
    private Models.Assignee _owner;
    private IEnumerable<Models.SubTask> _subTasks;

    public void SetId()
    {
        // Generate a unique ID. For example, using the current date/time.
        // Similar logic to how the coffee builder generates its ID.
        var date = DateTime.UtcNow.ToString("yy-MMM-dd");
        _id = $"project_task_{date}_{Guid.NewGuid().ToString().Substring(0, 8)}";
    }

    public void SetCreatedOn()
    {
        // Set the created on date/time to now
        _createdOn = DateTime.UtcNow;
    }

    public void SetTaskName()
    {
        // Assign a default project task name
        _taskName = "Implement New Feature";
    }

    public void SetTaskDescription()
    {
        // Describe what the task is about
        _taskDescription = "Implement and integrate the new feature as specified in the requirements document.";
    }

    public void SetTargetDate()
    {
        // Set a target date, e.g., one week from now
        _targetDate = DateTime.UtcNow.AddDays(7);
    }

    public void SetOwner()
    {
        // Assign an owner for the task
        _owner = new Models.Assignee
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Role = "Lead Developer"
        };
    }

    public void SetSubTasks()
    {
        // Define some default subtasks for the project
        var tasks = new List<Models.SubTask> {
                new("Review Requirements", 2),
                new("Design Solution", 4),
                new("Implement Code", 8),
                new("Write Tests", 3),
                new("Document Changes", 2)
            };

        _subTasks = tasks;
    }

    public PlannedTask BuildTask()
    {
        // Ensure all properties are set before building
        SetId();
        SetCreatedOn();
        SetTaskName();
        SetTaskDescription();
        SetTargetDate();
        SetOwner();
        SetSubTasks();

        return new PlannedTask
        {
            Id = _id,
            CreatedOn = _createdOn,
            TaskName = _taskName,
            TaskDescription = _taskDescription,
            TargetDate = _targetDate,
            Owner = _owner,
            SubTasks = _subTasks
        };
    }

    public static implicit operator PlannedTask(ProjectTaskBuilder builder)
    {
        return builder.BuildTask();
    }
}

