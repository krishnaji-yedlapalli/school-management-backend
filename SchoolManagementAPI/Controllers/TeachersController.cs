using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly ILogger<TeachersController> _logger;
    
    public TeachersController(ITeacherRepository teacherRepository, ILogger<TeachersController> logger)
    {
        _teacherRepository = teacherRepository;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all teachers
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
    {
        var teachers = await _teacherRepository.GetAllAsync();
        return Ok(teachers);
    }
    
    /// <summary>
    /// Get a specific teacher by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        
        if (teacher == null)
        {
            return NotFound($"Teacher with ID {id} not found");
        }
        
        return Ok(teacher);
    }
    
    /// <summary>
    /// Get teachers by class ID
    /// </summary>
    [HttpGet("class/{classId}")]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersByClass(int classId)
    {
        var teachers = await _teacherRepository.GetTeachersByClassIdAsync(classId);
        return Ok(teachers);
    }
    
    /// <summary>
    /// Get the class teacher for a specific class
    /// </summary>
    [HttpGet("class/{classId}/class-teacher")]
    public async Task<ActionResult<Teacher>> GetClassTeacher(int classId)
    {
        var teacher = await _teacherRepository.GetClassTeacherByClassIdAsync(classId);
        
        if (teacher == null)
        {
            return NotFound($"No class teacher found for class ID {classId}");
        }
        
        return Ok(teacher);
    }
    
    /// <summary>
    /// Create a new teacher
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Teacher>> CreateTeacher([FromBody] Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdTeacher = await _teacherRepository.AddAsync(teacher);
        return CreatedAtAction(nameof(GetTeacher), new { id = createdTeacher.Id }, createdTeacher);
    }
    
    /// <summary>
    /// Update an existing teacher
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher teacher)
    {
        if (id != teacher.Id)
        {
            return BadRequest("ID mismatch");
        }
        
        var exists = await _teacherRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Teacher with ID {id} not found");
        }
        
        await _teacherRepository.UpdateAsync(teacher);
        return NoContent();
    }
    
    /// <summary>
    /// Delete a teacher
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var exists = await _teacherRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"Teacher with ID {id} not found");
        }
        
        await _teacherRepository.DeleteAsync(id);
        return NoContent();
    }
}
