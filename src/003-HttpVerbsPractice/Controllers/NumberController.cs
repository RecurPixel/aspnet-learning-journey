using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NumbersController : ControllerBase
{
    private static List<int> _numbers = new List<int> { 10, 20, 30, 40, 50 };

    // GET /api/numbers → Get all numbers
    // GET /api/numbers/{index} → Get number at index
    // POST /api/numbers → Add a number (from body)
    // PUT /api/numbers/{index} → Update number at index
    // DELETE /api/numbers/{index} → Remove number at index
    // Return appropriate status codes (200, 201, 404, etc.)

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_numbers);
    }

    [HttpGet("{index:int}")]
    public ActionResult Get(int index)
    {
        if (index < 0 || index >= _numbers.Count)
        {
            return NotFound();
        }

        return Ok(_numbers[index]);
    }

    [HttpPost]
    public ActionResult Post([FromBody] int number)
    {
        _numbers.Add(number);
        return CreatedAtAction(nameof(Get), new { index = _numbers.Count - 1 }, number);
    }

    [HttpPut("{index}")]
    public ActionResult Put(int index, [FromBody] int number)
    {
        if (index < 0 || index >= _numbers.Count)
        {
            return NotFound();
        }

        _numbers[index] = number;

        return NoContent();
    }

    [HttpDelete("{index}")]
    public ActionResult Delete(int index)
    {
        if (index < 0 || index >= _numbers.Count)
        {
            return NotFound();
        }

        _numbers.RemoveAt(index);
        return NoContent();
    }
}
