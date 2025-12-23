# School Management API

A .NET Core Web API for managing schools, classes, students, and teachers with SQLite database.

## Project Structure

```
SchoolManagementAPI/
├── Controllers/                     # API Controllers
│   ├── SchoolsController.cs
│   ├── ClassesController.cs
│   ├── StudentsController.cs
│   └── TeachersController.cs
│
├── Models/                          # Data Models/Entities
│   ├── School.cs
│   ├── Class.cs
│   ├── Section.cs
│   ├── Student.cs
│   └── Teacher.cs
│
├── Data/                            # Database Context
│   ├── SchoolDbContext.cs
│   └── DbInitializer.cs
│
├── Repositories/                    # Repository Pattern
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── ISchoolRepository.cs
│   │   ├── IClassRepository.cs
│   │   ├── IStudentRepository.cs
│   │   └── ITeacherRepository.cs
│   │
│   └── Implementations/
│       ├── Repository.cs
│       ├── SchoolRepository.cs
│       ├── ClassRepository.cs
│       ├── StudentRepository.cs
│       └── TeacherRepository.cs
│
├── DTOs/                            # Data Transfer Objects
│   ├── SchoolDto.cs
│   ├── StudentDto.cs
│   └── TeacherDto.cs
│
├── Middleware/                      # Custom middleware
│   └── ExceptionHandlingMiddleware.cs
│
├── Migrations/                      # EF Core migrations (auto-generated)
│
├── Program.cs                       # Application entry point
├── appsettings.json                 # Configuration
└── SchoolManagementAPI.csproj       # Project file
```

## Installed Packages

- **Microsoft.EntityFrameworkCore.Sqlite** (10.0.1) - SQLite database provider
- **Microsoft.EntityFrameworkCore.Tools** (10.0.1) - Migration tools
- **Microsoft.EntityFrameworkCore.Design** (10.0.1) - Design-time tools
- **Swashbuckle.AspNetCore** (10.1.0) - Swagger/OpenAPI documentation

## Technology Stack

- **.NET 10.0**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite Database**
- **Swagger/OpenAPI**

## Getting Started

### Prerequisites
- .NET 10.0 SDK or later

### Build the Project
```bash
cd SchoolManagementAPI
dotnet build
```

### Run the API
```bash
dotnet run
```

### Access Swagger UI
Once running, navigate to: `https://localhost:5001/swagger`

## Next Steps

Follow the implementation plan to:
1. ✅ Create project and install dependencies
2. Create data models with relationships
3. Configure Entity Framework DbContext
4. Create and apply database migrations
5. Implement repository pattern
6. Create controllers
7. Configure Swagger documentation
8. Test all endpoints

## Database Schema

The system uses a hierarchical structure:
- **School** → **Classes** → **Students/Teachers**

### Entities
- **School**: Manages multiple classes
- **Class**: Contains students and has a class teacher
- **Student**: name, id, class, address, section
- **Teacher**: name, id, class teacher assignment
- **Section**: Enum or entity for class sections
# school-management-backend
