using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Data;

public static class DbInitializer
{
    public static void Initialize(SchoolDbContext context)
    {
        context.Database.EnsureCreated();
        
        // Check if database is already seeded
        if (context.Schools.Any())
        {
            return; // Database has been seeded
        }
        
        // Seed Schools
        var schools = new School[]
        {
            new School { Name = "Springfield Elementary", Address = "123 Main St, Springfield" },
            new School { Name = "Riverside High School", Address = "456 River Rd, Riverside" }
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
