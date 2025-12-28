using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Data;
using SchoolManagementAPI.Repositories.Interfaces;

namespace SchoolManagementAPI.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly SchoolDbContext _context;
    protected readonly DbSet<T> _dbSet;
    
    public Repository(SchoolDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    public virtual async Task DeleteAsync(int id)
    {
        // Demonstrating Raw SQL for data modification (DML)
        // Note: We need to know the table name. For generic repository, it's safer to use EF methods
        // but since you want to learn SQL, here is the command format:
        var tableName = _context.Model.FindEntityType(typeof(T))?.GetTableName();
        if (!string.IsNullOrEmpty(tableName))
        {
            var sql = $"DELETE FROM {tableName} WHERE Id = {{0}}";
            await _context.Database.ExecuteSqlRawAsync(sql, id);
        }
    }
    
    public virtual async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        return entity != null;
    }
}
