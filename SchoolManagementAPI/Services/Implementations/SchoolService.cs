using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;

namespace SchoolManagementAPI.Services.Implementations;

public class SchoolService : ISchoolService
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly ILogger<SchoolService> _logger;

    public SchoolService(ISchoolRepository schoolRepository, ILogger<SchoolService> logger)
    {
        _schoolRepository = schoolRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<School>> GetAllSchoolsAsync()
    {
        _logger.LogInformation("Fetching all schools");
        return await _schoolRepository.GetAllAsync();
    }

    public async Task<School?> GetSchoolByIdAsync(int id)
    {
        _logger.LogInformation("Fetching school with ID {Id}", id);
        return await _schoolRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Class>> GetSchoolClassesAsync(int schoolId)
    {
        _logger.LogInformation("Fetching classes for school with ID {SchoolId}", schoolId);
        return await _schoolRepository.GetClassesBySchoolIdAsync(schoolId);
    }

    public async Task<School> CreateSchoolAsync(School school)
    {
        _logger.LogInformation("Creating new school: {SchoolName}", school.Name);
        // Business Logic Example: Ensure name is trimmed
        school.Name = (school.Name ?? string.Empty).Trim();
        return await _schoolRepository.AddAsync(school);
    }

    public async Task UpdateSchoolAsync(int id, School school)
    {
        _logger.LogInformation("Updating school with ID {Id}", id);
        await _schoolRepository.UpdateAsync(school);
    }

    public async Task DeleteSchoolAsync(int id)
    {
        _logger.LogInformation("Deleting school with ID {Id}", id);
        await _schoolRepository.DeleteAsync(id);
    }

    public async Task<bool> SchoolExistsAsync(int id)
    {
        return await _schoolRepository.ExistsAsync(id);
    }
}
