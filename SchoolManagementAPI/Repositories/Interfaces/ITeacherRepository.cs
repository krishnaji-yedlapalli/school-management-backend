using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Interfaces;

public interface ITeacherRepository : IRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetTeachersByClassIdAsync(int classId);
    Task<Teacher?> GetClassTeacherByClassIdAsync(int classId);
}
