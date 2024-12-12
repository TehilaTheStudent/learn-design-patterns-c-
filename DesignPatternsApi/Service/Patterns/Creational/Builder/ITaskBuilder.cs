using System;

namespace DesignPatternsApi.Service.Patterns.Creational.Builder;

public interface ITaskBuilder
{
    void SetId();
    void SetCreatedOn();
    void SetTaskName();
    void SetTaskDescription();
    void SetTargetDate();
    void SetOwner();
    void SetSubTasks();
    PlannedTask BuildTask();
}

