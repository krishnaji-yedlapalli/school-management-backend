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
        // Using Raw SQL to fetch all schools
        return await _context.Schools
            .FromSqlRaw("SELECT * FROM Schools")
            .ToListAsync();
    }
    
    public override async Task<School?> GetByIdAsync(int id)
    {
        // Using Raw SQL with a parameter to fetch a specific school
        return await _context.Schools
            .FromSqlRaw("SELECT * FROM Schools WHERE Id = {0}", id)
            .FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Class>> GetClassesBySchoolIdAsync(int schoolId)
    {
        // Using Raw SQL to fetch classes for a specific school
        return await _context.Classes
            .FromSqlRaw("SELECT * FROM Classes WHERE SchoolId = {0}", schoolId)
            .ToListAsync();
    }
}
