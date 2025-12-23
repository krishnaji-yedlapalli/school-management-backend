using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Section Section { get; set; }
    public int ClassId { get; set; }
}
