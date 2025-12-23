using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassesController : ControllerBase
{
    private readonly IClassRepository _classRepository;
    private readonly ILogger<ClassesController> _logger;
    
    public ClassesController(IClassRepository classRepository, ILogger<ClassesController> logger)
    {
        _classRepository = classRepository;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all classes
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetAllClasses()
    {
        var classes = await _classRepository.GetAllAsync();
        return Ok(classes);
    }
    
    /// <summary>
    /// Get a specific class by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> GetClass(int id)
    {
        var classEntity = await _classRepository.GetByIdAsync(id);
        
        if (classEntity == null)
        {
            return NotFound($"Class with ID {id} not found");
        }
        
        return Ok(classEntity);
    }
    
    /// <summary>
    /// Get all students in a specific class
    /// </summary>
    [HttpGet("{id}/students")]
    public async Task<ActionResult<IEnumerable<Student>>> GetClassStudents(int id)
    {
        var classExists = await _classRepository.ExistsAsync(id);
        if (!classExists)
        {
            return NotFound($"Class with ID {id} not found");
        }
        
        var students = await _classRepository.GetStudentsByClassIdAsync(id);
        return Ok(students);
    }
    
    /// <summary>
    /// Get all teachers in a specific class
    /// </summary>
    [HttpGet("{id}/teachers")]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetClassTeachers(int id)
    {
        var classExists = await _classRepository.ExistsAsync(id);
        if (!classExists)
        {
            return NotFound($"Class with ID {id} not found");
        }
        
        var teachers = await _classRepository.GetTeachersByClassIdAsync(id);
        return Ok(teachers);
    }
    
    /// <summary>
    /// Create a new class
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Class>> CreateClass([FromBody] Class classEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdClass = await _classRepository.AddAsync(classEntity);
        return CreatedAtAction(nameof(GetClass), new { id = createdClass.Id }, createdClass);
    }
    
    /// <summary>
    /// Update an existing class
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, [FromBody] Class classEntity)
    {
        if (id != classEntity.Id)
        {
            return BadRequest("ID mismatch");
        }
        
        var exists = await _classRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Class with ID {id} not found");
        }
        
        await _classRepository.UpdateAsync(classEntity);
        return NoContent();
    }
    
    /// <summary>
    /// Delete a class
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        var exists = await _classRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Class with ID {id} not found");
        }
        
        await _classRepository.DeleteAsync(id);
        return NoContent();
    }
}
