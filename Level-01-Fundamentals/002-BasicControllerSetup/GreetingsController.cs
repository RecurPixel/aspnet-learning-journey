using Microsoft.AspNetCore.Mvc;

namespace BasicControllerSetup.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GreetingsController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Welcome to ASP.NET Core!");
    }

    [HttpGet("{name}")]
    public ActionResult GetByName(string name)
    {
        if (String.IsNullOrEmpty(name))
            return NotFound();

        return Ok($"Hello, {name}!");
    }

    [HttpGet("time")]
    public ActionResult GetTime()
    {
        return Ok(DateTime.Now);
    }
}
