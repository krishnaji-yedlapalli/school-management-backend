namespace SchoolManagementAPI.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Grade { get; set; }
    
    // Foreign key
    public int SchoolId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
