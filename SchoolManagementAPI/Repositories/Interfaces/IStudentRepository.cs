using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
    Task<IEnumerable<Student>> GetStudentsBySectionAsync(Section section);
}
