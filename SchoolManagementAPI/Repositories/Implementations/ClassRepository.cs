using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Repositories.Implementations;

public class ClassRepository : Repository<Class>, IClassRepository
{
    public ClassRepository(SchoolDbContext context) : base(context)
    {
    }
    
    public override async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _context.Classes
            .ToListAsync();
    }
    
    public override async Task<Class?> GetByIdAsync(int id)
    {
        return await _context.Classes
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
    {
        return await _context.Students
            .Where(s => s.ClassId == classId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Teacher>> GetTeachersByClassIdAsync(int classId)
    {
        return await _context.Teachers
            .Where(t => t.ClassId == classId)
            .ToListAsync();
    }
}
