namespace DesignPatternsApi.Service.Patterns.Creational.Builder;


public class Models
{
    public struct SubTask
    {
        public SubTask(string name, int estimatedEffortHours)
            => (Name, EstimatedEffortHours) = (name, estimatedEffortHours);

        public string Name { get; set; }
        public int EstimatedEffortHours { get; set; }
    }

    public struct Assignee
    {
        public Assignee(string name, string email, string role)
            => (Name, Email, Role) = (name, email, role);

        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

