using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly ILogger<SchoolsController> _logger;
    
    public SchoolsController(ISchoolRepository schoolRepository, ILogger<SchoolsController> logger)
    {
        _schoolRepository = schoolRepository;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all schools
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<School>>> GetAllSchools()
    {
        var schools = await _schoolRepository.GetAllAsync();
        return Ok(schools);
    }
    
    /// <summary>
    /// Get a specific school by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<School>> GetSchool(int id)
    {
        var school = await _schoolRepository.GetByIdAsync(id);
        
        if (school == null)
        {
            return NotFound($"School with ID {id} not found");
        }
        
        return Ok(school);
    }
    
    /// <summary>
    /// Get all classes for a specific school
    /// </summary>
    [HttpGet("{id}/classes")]
    public async Task<ActionResult<IEnumerable<Class>>> GetSchoolClasses(int id)
    {
        var schoolExists = await _schoolRepository.ExistsAsync(id);
        if (!schoolExists)
        {
            return NotFound($"School with ID {id} not found");
        }
        
        var classes = await _schoolRepository.GetClassesBySchoolIdAsync(id);
        return Ok(classes);
    }
    
    /// <summary>
    /// Create a new school
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<School>> CreateSchool([FromBody] School school)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdSchool = await _schoolRepository.AddAsync(school);
        return CreatedAtAction(nameof(GetSchool), new { id = createdSchool.Id }, createdSchool);
    }
    
    /// <summary>
    /// Update an existing school
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchool(int id, [FromBody] School school)
    {
        if (id != school.Id)
        {
            return BadRequest("ID mismatch");
        }
        
        var exists = await _schoolRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"School with ID {id} not found");
        }
        
        await _schoolRepository.UpdateAsync(school);
        return NoContent();
    }
    
    /// <summary>
    /// Delete a school
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchool(int id)
    {
        var exists = await _schoolRepository.ExistsAsync(id);
        if (!exists)
        {
            return NotFound($"School with ID {id} not found");
        }
        
        await _schoolRepository.DeleteAsync(id);
        return NoContent();
    }
}
