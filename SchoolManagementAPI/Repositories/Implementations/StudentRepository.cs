using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Repositories.Implementations;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(SchoolDbContext context) : base(context)
    {
    }
    
    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.Class)
            .ToListAsync();
    }
    
    public override async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    
    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
    {
        return await _context.Students
            .Where(s => s.ClassId == classId)
            .Include(s => s.Class)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Student>> GetStudentsBySectionAsync(Section section)
    {
        return await _context.Students
            .Where(s => s.Section == section)
            .Include(s => s.Class)
            .ToListAsync();
    }
}
