namespace SchoolManagementAPI.DTOs;

using SchoolManagementAPI.Models;

public class SchoolSummaryDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public SchoolBoard Board { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
