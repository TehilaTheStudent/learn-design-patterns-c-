namespace DesignPatternsApi.Service.Patterns.Behavioral.Observer;

public interface IObserver
{
    // Receives update from subject
    void Update(ISubject subject);
}

