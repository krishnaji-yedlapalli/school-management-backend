using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Repositories.Implementations;

public class SchoolRepository : Repository<School>, ISchoolRepository
{
    public SchoolRepository(SchoolDbContext context) : base(context)
    {
    }
    
    public override async Task<IEnumerable<School>> GetAllAsync()
    {
        return await _context.Schools
            .Include(s => s.Classes)
            .ToListAsync();
    }
    
    public override async Task<School?> GetByIdAsync(int id)
    {
        return await _context.Schools
            .Include(s => s.Classes)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    
    public async Task<IEnumerable<Class>> GetClassesBySchoolIdAsync(int schoolId)
    {
        return await _context.Classes
            .Where(c => c.SchoolId == schoolId)
            .Include(c => c.Students)
            .Include(c => c.Teachers)
            .ToListAsync();
    }
}
