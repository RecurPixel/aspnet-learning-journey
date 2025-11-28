using Microsoft.AspNetCore.Mvc;

namespace QueryParametersHandler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private List<Item> _items = new List<Item>
    {
        new("Laptop", 500.0m),
        new("Bag", 700.0m),
        new("Laptop", 100.0m),
    };

    [HttpGet]
    public ActionResult Index([FromQuery] string? term, decimal? minPrice, decimal? maxPrice)
    {
        var result = _items.AsQueryable();

        if (!string.IsNullOrEmpty(term))
        {
            result = result.Where(item => item.Term.Contains(term));
        }

        if (minPrice != null)
        {
            result = result.Where(item => item.Price >= minPrice);
        }

        if (maxPrice != null)
        {
            result = result.Where(item => item.Price <= maxPrice);
        }

        return Ok(result);
    }
}

record Item(string Term, decimal Price);
