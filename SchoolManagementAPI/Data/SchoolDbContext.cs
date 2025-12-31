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
        
        // Configure School -> Classes relationship (One-to-Many, but no navigation properties)
        modelBuilder.Entity<Class>()
            .HasOne<School>()
            .WithMany()
            .HasForeignKey(c => c.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure Class -> Students relationship (Student has Class navigation, Class does not have Students)
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany()
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure Class -> Teachers relationship (Teacher has Class navigation, Class does not have Teachers)
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Class)
            .WithMany()
            .HasForeignKey(t => t.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
