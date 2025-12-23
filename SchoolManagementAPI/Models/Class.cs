namespace SchoolManagementAPI.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Grade { get; set; }
    
    // Foreign key
    public int SchoolId { get; set; }
    
    // Navigation properties
    public School School { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
