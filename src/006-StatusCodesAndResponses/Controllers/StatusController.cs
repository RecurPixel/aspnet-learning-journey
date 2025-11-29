using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace StatusCodesAndResponses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private static List<Status> _statuses = new();

    [HttpGet("success")]
    public IActionResult SuccessStatus()
    {
        return Ok(_statuses);
    }

    [HttpGet("bad")]
    public IActionResult BadStatus()
    {
        return BadRequest("Bad data");
    }

    [HttpGet("{code}")]
    public IActionResult GetStatus(int code)
    {
        var status = _statuses.Where(status => status.Code == code).FirstOrDefault();

        if (status == null)
        {
            return NotFound();
        }

        return Ok(status);
    }

    [HttpPost]
    public IActionResult CreatedStatus(Status status)
    {
        _statuses.Add(status);
        return CreatedAtAction(nameof(GetStatus), new { code = status.Code }, status);
    }

    [HttpGet("serverError")]
    public IActionResult ServerErrorStatus()
    {
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}

public record Status(string Name, int Code);
