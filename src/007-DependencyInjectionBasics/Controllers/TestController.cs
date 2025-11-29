using DependencyInjectionBasics.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionBasics.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IGreetingService _greeting;

    public TestController(IGreetingService greeting)
    {
        _greeting = greeting;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var greet1 = _greeting.GetGreeting("Jhon Test");
        var greet2 = _greeting.GetGreeting("Jane Test");

        return Ok(new { greet1, greet2 });
    }
}
