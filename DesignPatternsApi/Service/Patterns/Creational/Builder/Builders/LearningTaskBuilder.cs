namespace DesignPatternsApi.Service.Patterns.Creational.Builder.Builders;

public class LearningTaskBuilder : ITaskBuilder
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
        // Similar logic to bakery: include a date stamp in the ID
        var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        _id = $"learning_{date}";
    }

    public void SetCreatedOn()
    {
        // Set when the learning task is created
        _createdOn = DateTime.UtcNow;
    }

    public void SetTaskName()
    {
        // Provide a meaningful name for the learning task
        _taskName = "Learn the Builder Pattern";
    }

    public void SetTaskDescription()
    {
        // Describe the learning goal
        _taskDescription = "Study the Builder Design Pattern using online tutorials, documentation, and practice exercises.";
    }

    public void SetTargetDate()
    {
        // Give a deadline for completing the learning material, e.g., in three days
        _targetDate = DateTime.UtcNow.AddDays(3);
    }

    public void SetOwner()
    {
        // Assign the learner who is responsible for completing this learning task
        _owner = new Models.Assignee
        {
            Name = "Jane Student",
            Email = "jane.student@example.com",
            Role = "Learner"
        };
    }

    public void SetSubTasks()
    {
        // Define subtasks relevant to learning the builder pattern
        var tasks = new List<Models.SubTask> {
                new("Read Builder Pattern Chapter (2 hours)", 2),
                new("Watch Builder Pattern Video (1 hour)", 1),
                new("Implement a sample Builder code exercise (3 hours)", 3),
                new("Write summary notes (1 hour)", 1)
            };

        _subTasks = tasks;
    }

    public PlannedTask BuildTask()
    {
        // Just like the bakery builder, call all Set methods before building
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

    public static implicit operator PlannedTask(LearningTaskBuilder builder)
    {
        return builder.BuildTask();
    }
}

