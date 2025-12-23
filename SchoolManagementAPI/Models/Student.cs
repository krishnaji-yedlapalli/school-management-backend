namespace SchoolManagementAPI.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Section Section { get; set; }
    
    // Foreign key
    public int ClassId { get; set; }
    
    // Navigation property
    public Class Class { get; set; } = null!;
}
