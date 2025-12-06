using Microsoft.AspNetCore.Mvc;
using SimpleApi.Models;

namespace SimpleApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class TaskController : ControllerBase
{
    private static List<TaskItem> _tasks = new List<TaskItem>();
    private static int _maxTasks;

    public TaskController(IConfiguration configuration)
    {
        if (string.IsNullOrEmpty(configuration["AppSettings:MaxTasks"]))
        {
            _maxTasks = 5;
        }
        else
        {
            _maxTasks = int.Parse(configuration["AppSettings:MaxTasks"]);
        }
    }

    /// <summary>
    /// Get All Tasks
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_tasks);
    }

    [HttpGet("{id}")]
    public ActionResult GetById(long id)
    {
        var task = _tasks.Where(task => task.Id == id).FirstOrDefault();

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public ActionResult Set([FromBody] TaskItem task)
    {
        if (_tasks.Count() >= _maxTasks)
        {
            return Ok("Not allowed");
        }

        task.Id = _tasks.Count() + 1;

        _tasks.Add(task);

        return Ok(_tasks);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpDelete("{id}")]
    public ActionResult Remove(long id)
    {
        var task = _tasks.Where(task => task.Id == id).FirstOrDefault();

        if (task == null)
        {
            return NotFound();
        }

        _tasks.Remove(task);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Update(long id, [FromBody] TaskItem taskItem)
    {
        var taskIndex = _tasks.FindIndex(task => task.Id == id && task.Id == taskItem.Id);

        if (taskIndex == -1)
        {
            return NotFound();
        }

        _tasks[taskIndex] = taskItem;

        return CreatedAtAction(nameof(GetById), new { id = taskItem.Id }, taskItem);
    }
}
