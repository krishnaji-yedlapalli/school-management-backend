namespace SchoolManagementAPI.DTOs;

using SchoolManagementAPI.Models;

public class SchoolDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public SchoolBoard Board { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string AcademicYear { get; set; } = string.Empty;
    public int MaxStudentsPerSection { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Pincode { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string Timezone { get; set; } = string.Empty;
    public bool AttendanceEnabled { get; set; }
    public bool FeesEnabled { get; set; }
    public bool ExamsEnabled { get; set; }
    public bool TransportEnabled { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
