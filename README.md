# EmployeeSalaryTracker

This application tracks employees and their salary history. It exposes an endpoint that returns a list of employees with details about their current salary and previous changes.

---

## Technologies

- C#, .NET 8
- Entity Framework Core In-Memory provider for easy testing and development
- AutoMapper for mapping entities to DTOs

---

## Architecture

The application is organized into three layers:

- API Layer (Controllers)
- Service Layer (Business logic)
- Data Layer (DbContext, entities, and repositories)

---

## Endpoint: Retrieve Employees with Salary History

- **GET** `/api/employees`

**Response Example**:
```json
[
  {
    "id": 1,
    "name": "Marko Marković",
    "currentSalary": 50000,
    "salaryHistory": [
      { "amount": 45000, "updated": "2025-02-06T19:13:59Z" },
      { "amount": 40000, "updated": "2024-08-06T19:13:59Z" }
    ]
  },
  ...
]
``` 
- currentSalary: the employee's current salary
- salaryHistory: a list of previous salary amounts and update dates (the current salary is not duplicated in the history)

---

## Running the Project

1. Open the solution in Visual Studio 
2. Set EmployeeSalaryTracker.APIas the startup project  
3. Use Swagger to test the endpoint and explore the API documentation  

---

## Notes

- The Employee and SalaryHistory entities have a one-to-many relationship:  
  - Each Employee can have multiple SalaryHistory records.  
  - Each SalaryHistory entry references a single Employee via the `EmployeeId` foreign key.  
- This models the historical changes of an employee’s salary over time, while the Employee table holds only the current salary.  
- CORS is enabled (`AllowAnyOrigin`, `AllowAnyMethod`, `AllowAnyHeader`) so this endpoint can be consumed by various clients (Web, Mobile, etc.).
- SeedData class to initialize the database with sample data at startup  

---

## Possible Extensions

- Additional CRUD endpoints (GetById, Create, Update, Delete)  
- Global exception-handling middleware for centralized error handling  
- Pagination and filtering for large datasets  
- Switching to a real database (SQL Server, PostgreSQL, etc.) instead of the In-Memory provider  
- API versioning (v1, v2, …) to maintain compatibility across clients  
- Authentication and authorization

---
