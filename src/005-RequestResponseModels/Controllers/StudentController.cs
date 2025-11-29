using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Models;

namespace RequestResponseModels.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static List<Student> _students = new();
    private static long _studentId = 1001;

    [HttpGet]
    public ActionResult<IEnumerable<StudentDTO>> GetStudents()
    {
        return _students.Select(item => StudentToDTO(item)).ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<StudentDTO> GetStudnet(long id)
    {
        var student = _students.Find(item => item.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return StudentToDTO(student);
    }

    [HttpPost]
    public ActionResult<StudentDTO> PostStudentDto(StudentDTO studentDTO)
    {
        var student = new Student
        {
            Id = _studentId++,
            FirstName = studentDTO.FirstName,
            LastName = studentDTO.LastName,
            Age = studentDTO.Age,
            SecretIdentifier = string.Concat(studentDTO.Id, "_student", studentDTO?.FirstName[0]),
        };

        _students.Add(student);

        return CreatedAtAction(nameof(GetStudnet), new { id = student.Id }, StudentToDTO(student));
    }

    private static StudentDTO StudentToDTO(Student student)
    {
        return new StudentDTO
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Age = student.Age,
        };
    }
}
