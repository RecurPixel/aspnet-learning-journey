namespace DependencyInjectionBasics.Services;

public interface IGreetingService
{
    string GetGreeting(string name);
}

public class GreetingService : IGreetingService
{
    public string GetGreeting(string name)
    {
        return $"Hello {name}!";
    }
}