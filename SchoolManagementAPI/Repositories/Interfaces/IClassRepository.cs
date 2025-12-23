using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Interfaces;

public interface IClassRepository : IRepository<Class>
{
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
    Task<IEnumerable<Teacher>> GetTeachersByClassIdAsync(int classId);
}
