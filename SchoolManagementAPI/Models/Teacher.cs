namespace SchoolManagementAPI.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public bool IsClassTeacher { get; set; }
    
    // Foreign key
    public int ClassId { get; set; }
    
    // Navigation property
    public Class Class { get; set; } = null!;
}
