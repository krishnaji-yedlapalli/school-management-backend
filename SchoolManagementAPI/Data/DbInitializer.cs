using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolDbContext context)
    {
        context.Database.Migrate();
        
        // Check if database is already seeded
        if (context.Schools.Any())
        {
            return; // Database has been seeded
        }
        
        // Seed Schools
        var schools = new School[]
        {
            new School 
            { 
                Code = "GVHS-01",
                Name = "Green Valley High School", 
                Board = SchoolBoard.CBSE,
                RegistrationNumber = "CBSE-REG-2023-98765",
                AcademicYear = "2024-2025",
                MaxStudentsPerSection = 40,
                Email = "info@greenvalleyschool.edu.in",
                Phone = "+91-9876543210",
                AddressLine1 = "Near Central Park, MG Road",
                City = "Hyderabad",
                State = "Telangana",
                Country = "India",
                Pincode = "500081",
                StartTime = "09:00",
                EndTime = "16:00",
                Timezone = "Asia/Kolkata",
                AttendanceEnabled = true,
                FeesEnabled = true,
                ExamsEnabled = true,
                TransportEnabled = false,
                IsActive = true,
                CreatedAt = DateTime.Parse("2024-04-01T10:15:30Z"),
                UpdatedAt = DateTime.Parse("2024-09-15T08:45:00Z")
            },
            new School 
            { 
                Code = "RHS-02",
                Name = "Riverside High School", 
                Board = SchoolBoard.ICSE,
                RegistrationNumber = "ICSE-REG-2023-12345",
                AcademicYear = "2024-2025",
                MaxStudentsPerSection = 35,
                Email = "contact@riverside.edu.in",
                Phone = "+91-8765432109",
                AddressLine1 = "456 River Rd",
                City = "Riverside",
                State = "California",
                Country = "USA",
                Pincode = "92501",
                StartTime = "08:30",
                EndTime = "15:30",
                Timezone = "America/Los_Angeles",
                AttendanceEnabled = true,
                FeesEnabled = true,
                ExamsEnabled = true,
                TransportEnabled = true,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
        context.Schools.AddRange(schools);
        context.SaveChanges();
        
        // Seed Classes
        var classes = new Class[]
        {
            new Class { Name = "Grade 5A", Grade = 5, SchoolId = schools[0].Id },
            new Class { Name = "Grade 5B", Grade = 5, SchoolId = schools[0].Id },
            new Class { Name = "Grade 10A", Grade = 10, SchoolId = schools[1].Id }
        };
        context.Classes.AddRange(classes);
        context.SaveChanges();
        
        // Seed Students
        var students = new Student[]
        {
            new Student { Name = "John Doe", Address = "789 Oak Ave", Section = Section.A, ClassId = classes[0].Id },
            new Student { Name = "Jane Smith", Address = "321 Pine St", Section = Section.A, ClassId = classes[0].Id },
            new Student { Name = "Bob Johnson", Address = "654 Elm Dr", Section = Section.B, ClassId = classes[1].Id },
            new Student { Name = "Alice Williams", Address = "987 Maple Ln", Section = Section.A, ClassId = classes[2].Id }
        };
        context.Students.AddRange(students);
        context.SaveChanges();
        
        // Seed Teachers
        var teachers = new Teacher[]
        {
            new Teacher { Name = "Mr. Anderson", Subject = "Mathematics", IsClassTeacher = true, ClassId = classes[0].Id },
            new Teacher { Name = "Ms. Davis", Subject = "English", IsClassTeacher = false, ClassId = classes[0].Id },
            new Teacher { Name = "Dr. Wilson", Subject = "Science", IsClassTeacher = true, ClassId = classes[1].Id },
            new Teacher { Name = "Mrs. Brown", Subject = "History", IsClassTeacher = true, ClassId = classes[2].Id }
        };
        context.Teachers.AddRange(teachers);
        context.SaveChanges();
    }
}
