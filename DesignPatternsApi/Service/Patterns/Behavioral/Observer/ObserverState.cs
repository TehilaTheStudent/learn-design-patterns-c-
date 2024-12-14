namespace DesignPatternsApi.Service.Patterns.Behavioral.Observer;
public class ObserverState
{
    public string TaskStates { get; set; } = "pending";
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}

