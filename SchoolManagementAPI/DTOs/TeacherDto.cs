namespace SchoolManagementAPI.DTOs;

public class TeacherDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public bool IsClassTeacher { get; set; }
    public int ClassId { get; set; }
}
