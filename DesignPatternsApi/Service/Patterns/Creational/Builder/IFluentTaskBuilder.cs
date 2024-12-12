namespace DesignPatternsApi.Service.Patterns.Creational.Builder;
public interface IFluentTaskBuilder
{
    IFluentTaskBuilder WithId(string id);
    IFluentTaskBuilder CreatedOn(DateTime creationTime);
    IFluentTaskBuilder Named(string taskName);
    IFluentTaskBuilder DescribedAs(string taskDescription);
    IFluentTaskBuilder WithTargetDate(DateTime targetDate);
    IFluentTaskBuilder OwnedBy(Models.Assignee owner);
    IFluentTaskBuilder WithSubTasks(List<Models.SubTask> subTasks);
    PlannedTask BuildTask();
}

