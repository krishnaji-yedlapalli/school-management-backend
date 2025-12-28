using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Interfaces;

public interface ISchoolService
{
    Task<IEnumerable<School>> GetAllSchoolsAsync();
    Task<School?> GetSchoolByIdAsync(int id);
    Task<IEnumerable<Class>> GetSchoolClassesAsync(int schoolId);
    Task<School> CreateSchoolAsync(School school);
    Task UpdateSchoolAsync(int id, School school);
    Task DeleteSchoolAsync(int id);
    Task<bool> SchoolExistsAsync(int id);
}
