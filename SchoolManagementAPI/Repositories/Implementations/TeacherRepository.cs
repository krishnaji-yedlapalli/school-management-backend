using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Repositories.Implementations;

public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    public TeacherRepository(SchoolDbContext context) : base(context)
    {
    }
    
    public override async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _context.Teachers
            .Include(t => t.Class)
            .ToListAsync();
    }
    
    public override async Task<Teacher?> GetByIdAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Class)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    
    public async Task<IEnumerable<Teacher>> GetTeachersByClassIdAsync(int classId)
    {
        return await _context.Teachers
            .Where(t => t.ClassId == classId)
            .Include(t => t.Class)
            .ToListAsync();
    }
    
    public async Task<Teacher?> GetClassTeacherByClassIdAsync(int classId)
    {
        return await _context.Teachers
            .Where(t => t.ClassId == classId && t.IsClassTeacher)
            .Include(t => t.Class)
            .FirstOrDefaultAsync();
    }
}
