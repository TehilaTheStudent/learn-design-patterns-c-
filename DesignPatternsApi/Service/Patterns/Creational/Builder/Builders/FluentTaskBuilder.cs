using DesignPatternsApi.Service.Patterns.Creational.Builder;
namespace DesignPatternsApi.Service.Patterns.Creational.Builder.Builders;
/// <summary>
/// Variation on the builder pattern that provides a Fluent syntax 
/// for constructing a new WorkTask instance.
/// </summary>
public class FluentTaskBuilder : IFluentTaskBuilder
{
    private string _id;
    private DateTime _createdOn;
    private string _taskName;
    private string _taskDescription;
    private DateTime _targetDate;
    private Models.Assignee _owner;
    private IEnumerable<Models.SubTask> _subTasks;

    public IFluentTaskBuilder WithId(string id)
    {
        _id = id;
        return this;
    }

    public IFluentTaskBuilder CreatedOn(DateTime creationTime)
    {
        _createdOn = creationTime;
        return this;
    }

    public IFluentTaskBuilder Named(string taskName)
    {
        _taskName = taskName;
        return this;
    }

    public IFluentTaskBuilder DescribedAs(string taskDescription)
    {
        _taskDescription = taskDescription;
        return this;
    }

    public IFluentTaskBuilder WithTargetDate(DateTime targetDate)
    {
        _targetDate = targetDate;
        return this;
    }

    public IFluentTaskBuilder OwnedBy(Models.Assignee owner)
    {
        _owner = owner;
        return this;
    }

    public IFluentTaskBuilder WithSubTasks(List<Models.SubTask> subTasks)
    {
        _subTasks = subTasks;
        return this;
    }

    public PlannedTask BuildTask()
    {
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

    public static implicit operator PlannedTask(FluentTaskBuilder builder)
    {
        return builder.BuildTask();
    }
}

