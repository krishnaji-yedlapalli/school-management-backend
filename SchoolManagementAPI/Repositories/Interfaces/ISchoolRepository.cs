using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Interfaces;

public interface ISchoolRepository : IRepository<School>
{
    Task<IEnumerable<Class>> GetClassesBySchoolIdAsync(int schoolId);
}
