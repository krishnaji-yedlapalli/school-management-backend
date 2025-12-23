using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Data;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {
    }
    
    public DbSet<School> Schools { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure School -> Classes relationship
        modelBuilder.Entity<School>()
            .HasMany(s => s.Classes)
            .WithOne(c => c.School)
            .HasForeignKey(c => c.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure Class -> Students relationship
        modelBuilder.Entity<Class>()
            .HasMany(c => c.Students)
            .WithOne(s => s.Class)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure Class -> Teachers relationship
        modelBuilder.Entity<Class>()
            .HasMany(c => c.Teachers)
            .WithOne(t => t.Class)
            .HasForeignKey(t => t.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
