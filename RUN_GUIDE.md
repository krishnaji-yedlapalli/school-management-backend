# Running the School Management Project

This guide provides the necessary commands to set up and run the project environment and the API.

## Prerequisites
- [Docker](https://www.docker.com/) and Docker Compose
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet tool install --global dotnet-ef`)

## 1. Infrastructure (Database)
Start the SQL Server database container:
```bash
docker-compose up -d
```

To stop the containers:
```bash
docker-compose down
```

## 2. Database Migrations
Ensure the database schema is up to date:
```bash
cd SchoolManagementAPI
dotnet ef database update
```

To add a new migration (if you modify models):
```bash
dotnet ef migrations add <MigrationName>
```

## 3. Running the API
Run the .NET API project:
```bash
cd SchoolManagementAPI
dotnet run
```
The API will be available at `http://localhost:5007` (or as configured in `launchSettings.json`).

## 4. Useful Development Commands
Build the project:
```bash
dotnet build
```

Clean the project:
```bash
dotnet clean
```

Restore dependencies:
```bash
dotnet restore
```
