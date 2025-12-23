using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<StudentsController> _logger;
    
    public StudentsController(IStudentRepository studentRepository, ILogger<StudentsController> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all students
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        var students = await _studentRepository.GetAllAsync();
        return Ok(students);
    }
    
    /// <summary>
    /// Get a specific student by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        
        if (student == null)
        {
            return NotFound($"Student with ID {id} not found");
        }
        
        return Ok(student);
    }
    
    /// <summary>
    /// Get students by class ID
    /// </summary>
    [HttpGet("class/{classId}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByClass(int classId)
    {
        var students = await _studentRepository.GetStudentsByClassIdAsync(classId);
        return Ok(students);
    }
    
    /// <summary>
    /// Get students by section
    /// </summary>
    [HttpGet("section/{section}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsBySection(Section section)
    {
        var students = await _studentRepository.GetStudentsBySectionAsync(section);
        return Ok(students);
    }
    
    /// <summary>
    /// Create a new student
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdStudent = await _studentRepository.AddAsync(student);
        return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
    }
    
    /// <summary>
    /// Update an existing student
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
    {
        if (id != student.Id)
        {
            return BadRequest("ID mismatch");
        }
        
        var exists = await _studentRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Student with ID {id} not found");
        }
        
        await _studentRepository.UpdateAsync(student);
        return NoContent();
    }
    
    /// <summary>
    /// Delete a student
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var exists = await _studentRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Student with ID {id} not found");
        }
        
        await _studentRepository.DeleteAsync(id);
        return NoContent();
    }
}
