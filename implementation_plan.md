Implementation Plan - School Management API

Problem Statement:
Create a .NET Core Web API with SQLite database to manage a school system with hierarchical relationships between schools, classes, students, and teachers. The system needs full CRUD operations with proper API documentation.

Requirements:
- Hierarchical structure: School → Classes → Students/Teachers
- Entities: School, Student, Teacher, Class, Section
- Student fields: name, id, class, address, section
- Teacher fields: name, id, class teacher assignment
- CRUD endpoints for all entities
- Controller-based API architecture
- SQLite database with Entity Framework Core
- Swagger/OpenAPI documentation
- No authentication required

Background:
Based on research, the optimal approach uses:
- ASP.NET Core Web API with Controller pattern for structured endpoints
- Entity Framework Core with SQLite for lightweight, cross-platform data persistence
- Swashbuckle.AspNetCore for automatic Swagger documentation generation
- Repository pattern for clean data access layer
- One-to-many relationships: School→Classes, Class→Students/Teachers
- Navigation properties for efficient querying and data integrity

Proposed Solution:
Build a layered architecture with:
1. Data models with proper EF Core relationships
2. DbContext with SQLite configuration
3. Repository pattern for data access
4. Controller-based API endpoints
5. Automatic Swagger documentation
6. Database migrations for schema management

Task Breakdown:

Task 1: Project Setup and Dependencies
- Create new ASP.NET Core Web API project
- Install required NuGet packages: Microsoft.EntityFrameworkCore.Sqlite, Swashbuckle.AspNetCore
- Configure basic project structure with folders for Models, Controllers, Data, Repositories
- Set up appsettings.json with SQLite connection string
- Demo: Empty API project runs successfully with Swagger UI accessible

Task 2: Create Data Models with Relationships
- Define School, Class, Section, Student, Teacher entities with proper properties
- Configure EF Core relationships using navigation properties and foreign keys
- Implement one-to-many relationships: School→Classes, Class→Students, Class→Teachers
- Add data annotations for validation and database constraints
- Demo: Models compile successfully with proper relationship structure

Task 3: Configure Entity Framework DbContext
- Create SchoolDbContext inheriting from DbContext
- Configure entity relationships using Fluent API
- Set up SQLite connection and database configuration
- Register DbContext in dependency injection container
- Demo: DbContext can be instantiated and connection string works

Task 4: Create and Apply Database Migrations
- Generate initial migration for all entities
- Apply migration to create SQLite database file
- Seed sample data for testing (1 school, 2 classes, sample students/teachers)
- Verify database schema and relationships are created correctly
- Demo: SQLite database file exists with proper tables and sample data

Task 5: Implement Repository Pattern
- Create generic IRepository interface with CRUD operations
- Implement SchoolRepository, StudentRepository, TeacherRepository, ClassRepository
- Add specific methods for complex queries (students by class, teacher assignments)
- Register repositories in dependency injection
- Demo: Repositories can perform basic CRUD operations on sample data

Task 6: Create School Management Controllers
- Implement SchoolsController with full CRUD endpoints
- Add ClassesController with CRUD and school association endpoints
- Include proper HTTP status codes, error handling, and validation
- Add XML documentation comments for Swagger generation
- Demo: School and Class endpoints work via Swagger UI with proper documentation

Task 7: Create Student and Teacher Controllers
- Implement StudentsController with CRUD operations and class filtering
- Implement TeachersController with CRUD operations and class teacher assignments
- Add endpoints for complex queries (students by class/section, teachers by school)
- Include proper error handling and validation responses
- Demo: All CRUD operations work for students and teachers via Swagger UI

Task 8: Configure Swagger Documentation and Final Integration
- Configure Swashbuckle with proper API information and XML comments
- Add response examples and detailed endpoint descriptions
- Test all endpoints with various scenarios and edge cases
- Add global exception handling middleware
- Demo: Complete API with full Swagger documentation, all endpoints functional and properly documented