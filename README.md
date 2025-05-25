# Project Overview

This project is a robust ASP.NET Core Web API built following Clean Architecture principles. It uses Oracle Database with Entity Framework Core and implements CQRS for clear separation of read and write operations.

---

## Technologies & Patterns

- **ASP.NET Core Web API**  
- **RESTful Controllers** with MediatR for handling Commands and Queries  
- **Entity Framework Core** (Code First approach) for database access  
- **CQRS (Command and Query Responsibility Segregation)** pattern  
- **DTOs (Data Transfer Objects)** for data encapsulation and validation  
- **AutoMapper** for mapping between Entities and DTOs  
- **Clean Architecture** with well-defined layers:  
  - Domain (Entities, Interfaces, DTOs)  
  - Infrastructure (Data Context, Repositories)  
  - API (Controllers, Middleware)  
  - Tests (Unit and Integration tests)  
- **Oracle Database 23c** utilizing Pluggable Database (PDB) with a dedicated user for the application  

---

## Project Structure

```
/src
  /Api           # Presentation layer (ASP.NET Core Web API)
  /Domain        # Domain entities, interfaces, DTOs, business logic
  /Infrastructure # Database context, repository implementations
  /Tests         # Automated tests (Not Implemented yet)

```

---

## Key Features

- Implements CRUD operations using Repository and Unit of Work patterns  
- Separation of Commands and Queries with MediatR  
- Configuration via `appsettings.json` including Oracle connection string  
- Enum properties mapped to string representations in API responses  
- Clean and maintainable codebase with DI and SOLID principles  

---

## Getting Started

1. Configure the Oracle Database connection string in `appsettings.json`  
2. Run database migrations using EF Core tools (Code First)  
3. Build and run the API project  
4. Access API documentation via Swagger UI  

---
