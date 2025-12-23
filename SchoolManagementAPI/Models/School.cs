namespace SchoolManagementAPI.Models;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Class> Classes { get; set; } = new List<Class>();
}
