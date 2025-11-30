# 🎯 ASP.NET Core Complete Learning Plan — 60 Problems

> **A structured, progressive path to master ASP.NET Core through hands-on problem-solving.**  
> Each level contains problems building upon previous knowledge.  
> Designed for developers who already know C# fundamentals.

---

## 📋 Prerequisites Checklist

Before starting, ensure you have:
- ✅ Completed C# fundamentals (variables, OOP, LINQ, async/await)
- ✅ .NET SDK 8 installed
- ✅ VS Code or Visual Studio ready
- ✅ SQL Server + SSMS installed
- ✅ Postman installed
- ✅ Basic understanding of HTTP/REST concepts

---

## 🌐 Level 1 — ASP.NET Core Fundamentals (Problems 1-10)

**Learning Goals:** Understand web application basics, routing, controllers, and HTTP fundamentals

**Reading Resources:**
- Microsoft Learn: [ASP.NET Core fundamentals](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/)
- Microsoft Docs: [Controllers and Actions](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/actions)

---

### ✅ Problem 1: Hello World Web API

**Topics:** Minimal API, Program.cs, HTTP GET

**Instructions:**
1. Create a new ASP.NET Core Web API project using `dotnet new webapi -n HelloWorldAPI`
2. Remove the default WeatherForecast files
3. Create a single GET endpoint at `/hello` that returns "Hello, ASP.NET Core!"
4. Test using browser and Postman

📝 **Learning Focus:** Understand Program.cs structure, app.MapGet(), and how routing works

---

### ✅ Problem 2: Basic Controller Setup

**Topics:** Controllers, ActionResults, Route attributes

**Instructions:**
1. Create a `GreetingController` with these endpoints:
   - `GET /api/greeting` → Returns "Welcome to ASP.NET Core!"
   - `GET /api/greeting/{name}` → Returns "Hello, {name}!"
   - `GET /api/greeting/time` → Returns current server time
2. Use proper `[Route]` and `[HttpGet]` attributes
3. Return `Ok()` with appropriate data

📝 **Learning Focus:** Controller structure, route parameters, ActionResult types

---

### ✅ Problem 3: HTTP Verbs Practice

**Topics:** GET, POST, PUT, DELETE, FromBody

**Instructions:**
1. Create a `NumberController` with an in-memory list of integers
2. Implement:
   - `GET /api/numbers` → Get all numbers
   - `GET /api/numbers/{index}` → Get number at index
   - `POST /api/numbers` → Add a number (from body)
   - `PUT /api/numbers/{index}` → Update number at index
   - `DELETE /api/numbers/{index}` → Remove number at index
3. Return appropriate status codes (200, 201, 404, etc.)

📝 **Learning Focus:** Different HTTP verbs, [FromBody] attribute, status codes

---

### ✅ Problem 4: Query Parameters Handler

**Topics:** Query strings, [FromQuery], model binding

**Instructions:**
1. Create a `SearchController` with endpoint: `GET /api/search`
2. Accept query parameters: `term` (string), `minPrice` (decimal?), `maxPrice` (decimal?)
3. Return a filtered result message based on parameters
4. Handle cases where parameters are missing using nullable types

Example: `/api/search?term=laptop&minPrice=500&maxPrice=1500`

📝 **Learning Focus:** Query parameter binding, nullable parameters, URL query strings

---

### ✅ Problem 5: Request/Response Models

**Topics:** DTOs, Model classes, Structured responses

**Instructions:**
1. Create a `Student` model class (Id, Name, Age, Grade)
2. Create a `StudentController` with an in-memory list
3. Implement `GET /api/students` returning List<Student>
4. Implement `POST /api/students` accepting Student from body
5. Implement `GET /api/students/{id}` with NotFound handling

📝 **Learning Focus:** Creating models, JSON serialization, working with complex types

---

### ✅ Problem 6: Status Codes and Responses

**Topics:** IActionResult, StatusCode methods, problem details

**Instructions:**
1. Create a `StatusController` with endpoints demonstrating:
   - `200 OK` with data
   - `201 Created` with location header
   - `204 No Content`
   - `400 Bad Request` with error message
   - `404 Not Found`
   - `500 Internal Server Error`
2. Each endpoint should demonstrate the appropriate use case

📝 **Learning Focus:** HTTP status codes, when to use each, proper API responses

---

### ✅ Problem 7: Dependency Injection Basics

**Topics:** Constructor injection, AddSingleton, AddScoped

**Instructions:**
1. Create an interface `IGreetingService` with method `GetGreeting(string name)`
2. Implement `GreetingService` class
3. Register in Program.cs as Scoped
4. Inject into a controller and use it
5. Create endpoints to test the service

📝 **Learning Focus:** DI container, service lifetimes, constructor injection pattern

---

### ✅ Problem 8: Configuration and appsettings.json

**Topics:** IConfiguration, appsettings.json, Options pattern

**Instructions:**
1. Add custom settings to appsettings.json:
   ```json
   {
     "AppSettings": {
       "ApplicationName": "MyAPI",
       "MaxItemsPerPage": 10,
       "AdminEmail": "admin@example.com"
     }
   }
   ```
2. Create a `ConfigController` that reads and displays these settings
3. Use `IConfiguration` to access values

📝 **Learning Focus:** Configuration management, reading appsettings, environment-specific configs

---

### ✅ Problem 9: Middleware Basics

**Topics:** app.Use(), middleware pipeline, request/response manipulation

**Instructions:**
1. Create custom middleware that:
   - Logs incoming request path and method
   - Adds a custom header "X-Custom-Header" to response
   - Measures request processing time
2. Register in Program.cs before controllers
3. Test with any endpoint

📝 **Learning Focus:** Middleware pipeline, request/response interception, execution order

---

### Problem 10: Simple API with Multiple Controllers

**Topics:** Integration of previous concepts

**Instructions:**
1. Build a simple "Task Manager API" with:
   - `TaskItem` model (Id, Title, Description, IsCompleted)
   - `TaskController` with full CRUD operations
   - In-memory storage using a static list
   - Proper status codes and error handling
   - Configuration for "MaxTasks" from appsettings
2. Document your API with clear endpoint descriptions

📝 **Learning Focus:** Bringing together routing, controllers, models, DI, and configuration

---

## 🗄️ Level 2 — Entity Framework Core & Databases (Problems 11-20)

**Learning Goals:** Master EF Core, database operations, migrations, and relationships

**Reading Resources:**
- Microsoft Learn: [EF Core Overview](https://learn.microsoft.com/en-us/ef/core/)
- Microsoft Docs: [Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)

---

### Problem 11: First DbContext Setup

**Topics:** DbContext, DbSet, Connection strings

**Instructions:**
1. Install `Microsoft.EntityFrameworkCore.SqlServer` package
2. Create a `Book` entity (Id, Title, Author, Year)
3. Create `AppDbContext` inheriting from DbContext
4. Add connection string to appsettings.json
5. Register DbContext in Program.cs
6. Create initial migration and update database

📝 **Learning Focus:** DbContext basics, connection strings, package management

---

### Problem 12: CRUD with Database

**Topics:** EF Core queries, SaveChanges, async operations

**Instructions:**
1. Create a `BookController` using the DbContext from Problem 11
2. Implement all CRUD operations using EF Core:
   - GET all books (async)
   - GET book by ID
   - POST new book
   - PUT update book
   - DELETE book
3. Use async/await for all database operations
4. Handle cases where book doesn't exist

📝 **Learning Focus:** EF Core CRUD operations, async database calls, entity tracking

---

### Problem 13: LINQ Queries with EF Core

**Topics:** Where, OrderBy, Select, filtering

**Instructions:**
1. Add more books to database (seed data)
2. Create endpoints in `BookController`:
   - `GET /api/books/search?author={name}` - filter by author
   - `GET /api/books/year/{year}` - books from specific year
   - `GET /api/books/recent?count=5` - get recent books ordered by year
   - `GET /api/books/authors` - return distinct list of authors
3. Use LINQ queries with EF Core

📝 **Learning Focus:** Translating LINQ to SQL, query optimization, projection

---

### Problem 14: One-to-Many Relationship

**Topics:** Navigation properties, Include, foreign keys

**Instructions:**
1. Create entities:
   - `Category` (Id, Name)
   - Update `Book` to include `CategoryId` and navigation property
2. Configure relationship in DbContext
3. Create migration and update database
4. Create `CategoryController` with CRUD
5. Modify `BookController` GET methods to include category data using `.Include()`

📝 **Learning Focus:** Relationships, eager loading, navigation properties

---

### Problem 15: Many-to-Many Relationship

**Topics:** Join tables, many-to-many configuration

**Instructions:**
1. Create entities:
   - `Author` (Id, Name, Biography)
   - `BookAuthor` join entity
   - Update `Book` to have collection of Authors
2. Configure many-to-many relationship
3. Create migration
4. Create endpoints to:
   - Get all books by an author
   - Get all authors of a book
   - Add author to a book
   - Remove author from a book

📝 **Learning Focus:** Many-to-many relationships, join tables, complex queries

---

### Problem 16: Repository Pattern

**Topics:** Repository pattern, abstraction, unit of work

**Instructions:**
1. Create `IRepository<T>` interface with generic CRUD methods
2. Implement `Repository<T>` class
3. Create specific `IBookRepository` interface with custom methods
4. Implement `BookRepository` inheriting from `Repository<Book>`
5. Register repositories in DI container
6. Refactor controller to use repository instead of DbContext directly

📝 **Learning Focus:** Repository pattern, separation of concerns, abstraction layers

---

### Problem 17: Database Seeding

**Topics:** ModelBuilder, HasData, initial data

**Instructions:**
1. Override `OnModelCreating` in DbContext
2. Use `HasData()` to seed:
   - 5 categories
   - 20 books with category relationships
   - 10 authors
3. Create and apply migration
4. Verify data through API endpoints

📝 **Learning Focus:** Data seeding, migrations with data, initial database setup

---

### Problem 18: Pagination Implementation

**Topics:** Skip, Take, query optimization

**Instructions:**
1. Create a `PaginationParams` model (PageNumber, PageSize)
2. Create a `PagedResult<T>` model (Items, TotalCount, PageNumber, TotalPages)
3. Implement pagination in `BookController`:
   - `GET /api/books/paged?pageNumber=1&pageSize=10`
4. Return total count and calculate total pages
5. Add validation for page parameters

📝 **Learning Focus:** Pagination, efficient queries, API design patterns

---

### Problem 19: Soft Delete Implementation

**Topics:** Query filters, global filters, soft delete pattern

**Instructions:**
1. Add `IsDeleted` property to `Book` entity
2. Configure global query filter in `OnModelCreating`:
   ```csharp
   modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
   ```
3. Update DELETE endpoint to set `IsDeleted = true` instead of removing
4. Create `GET /api/books/deleted` endpoint that uses `IgnoreQueryFilters()`
5. Create `POST /api/books/{id}/restore` endpoint

📝 **Learning Focus:** Query filters, soft deletes, entity state management

---

### Problem 20: Database Transactions

**Topics:** Transactions, BeginTransaction, rollback

**Instructions:**
1. Create endpoint `POST /api/books/bulk` that adds multiple books
2. Wrap operation in a transaction
3. If any book fails validation, rollback entire transaction
4. Demonstrate both success and failure scenarios
5. Add proper error handling and status codes

📝 **Learning Focus:** Transactions, data consistency, error handling in databases

---

## 🔐 Level 3 — Authentication & Authorization (Problems 21-30)

**Learning Goals:** Implement JWT authentication, role-based authorization, and security best practices

**Reading Resources:**
- Microsoft Learn: [Authentication and Authorization](https://learn.microsoft.com/en-us/aspnet/core/security/)
- JWT.io: [Introduction to JWT](https://jwt.io/introduction)

---

### Problem 21: User Model and Registration

**Topics:** User entity, password hashing, registration endpoint

**Instructions:**
1. Create `User` entity (Id, Username, Email, PasswordHash, CreatedAt)
2. Create `RegisterDto` (Username, Email, Password)
3. Create `AuthController` with `POST /api/auth/register`
4. Hash password using `BCrypt.Net-Next` package
5. Store user in database
6. Return success message (don't return password!)

📝 **Learning Focus:** User management, password security, DTOs for security

---

### Problem 22: Login and JWT Generation

**Topics:** JWT tokens, claims, authentication

**Instructions:**
1. Install `Microsoft.AspNetCore.Authentication.JwtBearer` and `System.IdentityModel.Tokens.Jwt`
2. Create `LoginDto` (Email, Password)
3. Create `POST /api/auth/login` endpoint that:
   - Verifies email exists
   - Validates password hash
   - Generates JWT token with claims (UserId, Email)
   - Returns token in response
4. Add JWT configuration to appsettings.json

📝 **Learning Focus:** JWT token generation, claims, authentication flow

---

### Problem 23: JWT Authentication Setup

**Topics:** Authentication middleware, JwtBearer configuration

**Instructions:**
1. Configure JWT authentication in Program.cs:
   ```csharp
   builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options => { /* configuration */ });
   ```
2. Add `app.UseAuthentication()` and `app.UseAuthorization()` to pipeline
3. Create a test endpoint with `[Authorize]` attribute
4. Test with and without token in Postman (Authorization: Bearer {token})

📝 **Learning Focus:** Authentication middleware, protecting endpoints, bearer tokens

---

### Problem 24: Role-Based Authorization

**Topics:** Roles, claims, [Authorize] with roles

**Instructions:**
1. Add `Role` property to User entity (enum: User, Admin, Moderator)
2. Include role claim in JWT token generation
3. Create protected endpoints:
   - `[Authorize]` - any authenticated user
   - `[Authorize(Roles = "Admin")]` - admin only
   - `[Authorize(Roles = "Admin,Moderator")]` - multiple roles
4. Test access with different user roles

📝 **Learning Focus:** Role-based authorization, claims-based security

---

### Problem 25: Getting Current User

**Topics:** HttpContext.User, ClaimsPrincipal, user context

**Instructions:**
1. Create a helper method to extract userId from JWT token:
   ```csharp
   var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
   ```
2. Create endpoints:
   - `GET /api/users/me` - returns current user's profile
   - `PUT /api/users/me` - updates current user's profile
3. Ensure users can only access/modify their own data

📝 **Learning Focus:** Accessing authenticated user context, user-specific operations

---

### Problem 26: Refresh Tokens

**Topics:** Refresh tokens, token rotation, security

**Instructions:**
1. Create `RefreshToken` entity (Token, UserId, ExpiresAt, CreatedAt)
2. On login, generate both access token (short-lived, 15min) and refresh token (long-lived, 7 days)
3. Create `POST /api/auth/refresh` endpoint:
   - Accepts refresh token
   - Validates token and expiration
   - Issues new access token
4. Store refresh tokens in database

📝 **Learning Focus:** Token refresh flow, token lifecycle, security best practices

---

### Problem 27: Authorization Policies

**Topics:** Custom policies, policy-based authorization

**Instructions:**
1. Create custom authorization requirements:
   - Must be account owner OR admin
   - Must have verified email
2. Define policies in Program.cs:
   ```csharp
   builder.Services.AddAuthorization(options =>
   {
       options.AddPolicy("MustBeOwnerOrAdmin", policy =>
           policy.RequireAssertion(context => /* logic */));
   });
   ```
3. Apply policies to endpoints using `[Authorize(Policy = "PolicyName")]`

📝 **Learning Focus:** Custom authorization policies, complex authorization logic

---

### Problem 28: Resource-Based Authorization

**Topics:** IAuthorizationService, resource-specific authorization

**Instructions:**
1. Create a `Post` entity (Id, Title, Content, UserId)
2. Implement authorization handler that checks if user owns the post
3. Use `IAuthorizationService` in controller:
   ```csharp
   var authResult = await _authorizationService
       .AuthorizeAsync(User, post, "MustBeOwner");
   ```
4. Apply to PUT and DELETE post endpoints

📝 **Learning Focus:** Resource-based authorization, authorization handlers

---

### Problem 29: API Key Authentication

**Topics:** Custom authentication schemes, middleware

**Instructions:**
1. Create API key authentication middleware
2. Store API keys in configuration or database
3. Check for "X-API-Key" header in requests
4. Allow endpoints to use either JWT OR API key
5. Create endpoints for API key management (for admins only)

📝 **Learning Focus:** Multiple authentication schemes, API key pattern

---

### Problem 30: Secure User Management System

**Topics:** Integration of all auth concepts

**Instructions:**
1. Build complete user management API with:
   - Registration with email verification flag
   - Login with JWT + refresh token
   - Profile management (own profile only)
   - Admin endpoints (view all users, roles management)
   - Password change (requires old password)
   - Password reset flow (simplified)
2. Implement proper authorization at all levels
3. Add logging for security events

📝 **Learning Focus:** Complete authentication system, security architecture

---

## ✅ Level 4 — Validation & Error Handling (Problems 31-40)

**Learning Goals:** Master input validation, error handling, custom exceptions, and API robustness

**Reading Resources:**
- Microsoft Learn: [Model Validation](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation)
- FluentValidation Docs: [FluentValidation](https://docs.fluentvalidation.net/)

---

### Problem 31: Data Annotations Validation

**Topics:** ModelState, validation attributes, automatic validation

**Instructions:**
1. Create a `ProductDto` with validation attributes:
   - `[Required]` on Name
   - `[StringLength]` on Description
   - `[Range]` on Price
   - `[EmailAddress]` on ContactEmail
2. Create POST endpoint for products
3. Check `ModelState.IsValid` and return 400 with errors if invalid
4. Test with various invalid inputs

📝 **Learning Focus:** Built-in validation attributes, ModelState, validation errors

---

### Problem 32: Custom Validation Attributes

**Topics:** Creating custom validators, ValidationAttribute

**Instructions:**
1. Create custom validation attributes:
   - `[FutureDate]` - ensures date is in future
   - `[AllowedFileExtensions(string[] extensions)]`
   - `[MinimumAge(int age)]`
2. Apply to DTOs and test
3. Return detailed validation error messages

📝 **Learning Focus:** Custom validation logic, reusable validators

---

### Problem 33: FluentValidation Introduction

**Topics:** FluentValidation library, validator classes

**Instructions:**
1. Install `FluentValidation.AspNetCore` package
2. Create a `CreateBookDto` and `BookValidator` class
3. Implement validation rules using fluent syntax:
   ```csharp
   RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
   RuleFor(x => x.Year).InclusiveBetween(1000, DateTime.Now.Year);
   ```
4. Register validators in Program.cs
5. Test validation automatically happening on POST

📝 **Learning Focus:** FluentValidation setup, fluent syntax, complex validations

---

### Problem 34: Complex FluentValidation Rules

**Topics:** Custom validators, async validation, conditional rules

**Instructions:**
1. Create validation rules that:
   - Check if email already exists in database (async)
   - Apply different rules based on user role
   - Validate dependent properties (e.g., EndDate must be after StartDate)
   - Use `.Must()` for custom logic
2. Implement in a user registration validator

📝 **Learning Focus:** Advanced validation scenarios, async validation, conditional logic

---

### Problem 35: Global Exception Handler

**Topics:** Exception handling middleware, ProblemDetails

**Instructions:**
1. Create custom exception classes:
   - `NotFoundException`
   - `BadRequestException`
   - `UnauthorizedException`
2. Create global exception handling middleware that catches all exceptions
3. Return appropriate status codes and ProblemDetails format:
   ```json
   {
     "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
     "title": "Not Found",
     "status": 404,
     "detail": "Book with ID 5 was not found"
   }
   ```
4. Log exceptions before returning response

📝 **Learning Focus:** Global error handling, ProblemDetails standard, custom exceptions

---

### Problem 36: Action Filters for Validation

**Topics:** Action filters, validation filter attribute

**Instructions:**
1. Create a `ValidateModelAttribute` action filter:
   ```csharp
   public class ValidateModelAttribute : ActionFilterAttribute
   {
       public override void OnActionExecuting(ActionExecutingContext context)
       {
           if (!context.ModelState.IsValid)
           {
               context.Result = new BadRequestObjectResult(context.ModelState);
           }
       }
   }
   ```
2. Apply globally or to specific controllers
3. Remove manual ModelState checks from controllers

📝 **Learning Focus:** Action filters, DRY principle, automatic validation

---

### Problem 37: Result Pattern Implementation

**Topics:** Result pattern, error handling without exceptions

**Instructions:**
1. Create a `Result<T>` class:
   ```csharp
   public class Result<T>
   {
       public bool IsSuccess { get; set; }
       public T Data { get; set; }
       public string ErrorMessage { get; set; }
       public List<string> Errors { get; set; }
   }
   ```
2. Create service layer that returns `Result<T>` instead of throwing exceptions
3. Handle results in controller and return appropriate responses
4. Compare with exception-based error handling

📝 **Learning Focus:** Result pattern, functional error handling, service layer design

---

### Problem 38: Centralized Error Response Format

**Topics:** Consistent API responses, error standardization

**Instructions:**
1. Create a standard `ApiResponse<T>` wrapper:
   ```csharp
   public class ApiResponse<T>
   {
       public bool Success { get; set; }
       public T Data { get; set; }
       public List<string> Errors { get; set; }
       public string Message { get; set; }
   }
   ```
2. Create extension methods or base controller to wrap all responses
3. Ensure all endpoints return consistent format
4. Handle both success and error scenarios

📝 **Learning Focus:** API design consistency, response standardization

---

### Problem 39: Request Validation Pipeline

**Topics:** Middleware, request validation, security

**Instructions:**
1. Create validation middleware that:
   - Checks request size limits
   - Validates content-type headers
   - Checks for required headers
   - Validates query parameter formats
2. Register before controllers
3. Return 400 Bad Request for invalid requests
4. Log validation failures

📝 **Learning Focus:** Request-level validation, security best practices, middleware chains

---

### Problem 40: Comprehensive Validation System

**Topics:** Integration of all validation concepts

**Instructions:**
1. Build a complete "Order Management" API with:
   - Order entity with multiple properties requiring validation
   - FluentValidation for complex business rules
   - Custom validation for stock availability (async DB check)
   - Global exception handler
   - Action filters for automatic validation
   - Standardized error responses
   - Proper logging at all levels
2. Include edge cases and error scenarios

📝 **Learning Focus:** Production-ready validation architecture, error handling strategy

---

## 📝 Level 5 — Advanced Features (Problems 41-50)

**Learning Goals:** Master logging, caching, background tasks, file uploads, and advanced ASP.NET features

**Reading Resources:**
- Microsoft Learn: [Logging](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)
- Microsoft Learn: [Caching](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory)

---

### Problem 41: Structured Logging with Serilog

**Topics:** Serilog, structured logging, log enrichment

**Instructions:**
1. Install `Serilog.AspNetCore` and sinks (Console, File)
2. Configure Serilog in Program.cs
3. Add structured logging throughout your API:
   - Log requests (method, path, user)
   - Log database queries
   - Log exceptions with context
4. Write logs to both console and file with different levels
5. Use structured properties: `Log.Information("User {UserId} created order {OrderId}", userId, orderId)`

📝 **Learning Focus:** Structured logging, Serilog configuration, log levels

---

### Problem 42: In-Memory Caching

**Topics:** IMemoryCache, cache strategies, cache invalidation

**Instructions:**
1. Inject `IMemoryCache` into a service
2. Create a cached endpoint for frequently accessed data:
   - Cache product list for 5 minutes
   - Cache individual products by ID
3. Implement cache-aside pattern:
   - Check cache first
   - If miss, fetch from DB and cache
4. Add endpoints to manually invalidate cache
5. Log cache hits and misses

📝 **Learning Focus:** Memory caching, cache patterns, performance optimization

---

### Problem 43: Distributed Caching with Redis

**Topics:** IDistributedCache, Redis, serialization

**Instructions:**
1. Install `Microsoft.Extensions.Caching.StackExchangeRedis`
2. Configure Redis connection in appsettings.json
3. Add distributed caching in Program.cs
4. Create cached endpoints using `IDistributedCache`:
   - Store complex objects (serialize to JSON)
   - Set expiration times
   - Handle cache misses
5. Compare performance with and without cache

📝 **Learning Focus:** Distributed caching, Redis basics, scalability considerations

---

### Problem 44: Background Services

**Topics:** IHostedService, BackgroundService, long-running tasks

**Instructions:**
1. Create a background service that runs every 30 seconds:
   - Checks for pending tasks
   - Processes them
   - Logs completion
2. Create another background service that cleans up old data daily
3. Register services in Program.cs
4. Add endpoints to trigger processing manually
5. Handle graceful shutdown

📝 **Learning Focus:** Background tasks, hosted services, application lifecycle

---

### Problem 45: File Upload and Storage

**Topics:** IFormFile, file validation, storage

**Instructions:**
1. Create endpoint `POST /api/files/upload` accepting file upload
2. Validate:
   - File size (max 5MB)
   - Allowed extensions (.jpg, .png, .pdf)
   - File name sanitization
3. Save file to disk with unique name
4. Store file metadata in database (filename, size, upload date, userId)
5. Create `GET /api/files/{id}` to download file
6. Create `GET /api/files` to list user's files

📝 **Learning Focus:** File handling, multipart form data, file security

---

### Problem 46: Response Compression

**Topics:** Response compression, performance optimization

**Instructions:**
1. Add response compression middleware:
   ```csharp
   builder.Services.AddResponseCompression(options =>
   {
       options.EnableForHttps = true;
       options.Providers.Add<GzipCompressionProvider>();
   });
   ```
2. Create endpoint returning large JSON payload
3. Test with and without compression using Postman
4. Measure response size difference
5. Configure compression levels

📝 **Learning Focus:** Response compression, performance tuning, HTTP optimization

---

### Problem 47: Rate Limiting

**Topics:** Rate limiting, throttling, protection

**Instructions:**
1. Install `AspNetCoreRateLimit` package
2. Configure rate limiting:
   - 10 requests per minute per IP
   - 100 requests per minute per authenticated user
   - Different limits for different endpoints
3. Return 429 (Too Many Requests) when limit exceeded
4. Add rate limit headers to response
5. Test rate limiting with multiple requests

📝 **Learning Focus:** Rate limiting, API protection, abuse prevention

---

### Problem 48: API Versioning

**Topics:** URL versioning, header versioning, version management

**Instructions:**
1. Install `Microsoft.AspNetCore.Mvc.Versioning`
2. Configure API versioning in Program.cs
3. Create two versions of an endpoint:
   - `GET /api/v1/products` - returns basic info
   - `GET /api/v2/products` - returns detailed info with additional fields
4. Use `[ApiVersion("1.0")]` and `[ApiVersion("2.0")]` attributes
5. Test both versions

📝 **Learning Focus:** API versioning strategies, backward compatibility, API evolution

---

### Problem 49: Health Checks

**Topics:** Health check endpoints, monitoring, readiness probes

**Instructions:**
1. Add health checks in Program.cs:
   ```csharp
   builder.Services.AddHealthChecks()
       .AddDbContextCheck<AppDbContext>()
       .AddUrlGroup(new Uri("https://example.com"), "external-api");
   ```
2. Create custom health check for critical business logic
3. Map health check endpoints:
   - `/health` - basic health
   - `/health/ready` - readiness check (DB, external services)
   - `/health/live` - liveness check (application responsive)
4. Return detailed health status

📝 **Learning Focus:** Health monitoring, observability, deployment readiness

---

### Problem 50: Advanced API Features Integration

**Topics:** Bringing together advanced concepts

**Instructions:**
1. Build a "Document Management API" that includes:
   - File upload with validation
   - Cached document metadata retrieval
   - Background service for virus scanning simulation
   - Rate limiting per user
   - Structured logging throughout
   - Health checks for storage and database
   - API versioning (v1 and v2 with different features)
   - Response compression
2. Implement proper error handling and monitoring
3. Add comprehensive documentation

📝 **Learning Focus:** Production-ready API design, feature integration, scalability

---

## 🚀 Level 6 — Real-World Projects (Problems 51-60)

**Learning Goals:** Build complete, production-ready APIs integrating all learned concepts

---

### Problem 51: Blog API - Part 1 (Core Features)

**Topics:** Integration project - setup and basic features

**Instructions:**
1. Design and implement:
   - Entities: User, Post, Comment, Tag (with relationships)
   - Authentication (JWT)
   - CRUD for posts with author verification
   - CRUD for comments (nested under posts)
   - Tag system (many-to-many with posts)
2. Use repository pattern
3. Add FluentValidation for all operations
4. Implement pagination for posts and comments

📝 **Learning Focus:** API design, data modeling, business logic

---

### Problem 52: Blog API - Part 2 (Advanced Features)

**Topics:** Adding advanced capabilities

**Instructions:**
1. Extend the blog API with:
   - Search functionality (title, content, tags)
   - Filtering (by author, date range, tags)
   - Sorting (date, popularity, title)
   - Like/Unlike system for posts
   - View count tracking
   - Featured posts
   - Draft/Published status
2. Add caching for popular posts
3. Implement background service to calculate trending posts

📝 **Learning Focus:** Search and filtering, complex queries, performance optimization

---

### Problem 53: Blog API - Part 3 (Production Features)

**Topics:** Production-ready features and deployment prep

**Instructions:**
1. Add production features:
   - Serilog with file and console logging
   - Global exception handler with ProblemDetails
   - Response compression
   - Rate limiting (stricter for anonymous users)
   - Health checks (database, external services)
   - API versioning (v1 and v2)
   - CORS configuration
   - Swagger/OpenAPI documentation with auth
2. Add admin endpoints (user management, content moderation)
3. Implement soft deletes for posts and comments
4. Add audit logging for critical operations

📝 **Learning Focus:** Production readiness, security hardening, observability

---

### Problem 54: E-Commerce API - Part 1 (Product Catalog)

**Topics:** Complex domain modeling

**Instructions:**
1. Design and implement:
   - Entities: Product, Category, Brand, ProductImage, Inventory
   - Hierarchical categories (parent-child relationships)
   - Product variants (size, color) with separate inventory
   - Image upload and management
   - Product search with filters (price range, category, brand, rating)
2. Implement pagination and sorting
3. Add caching for category tree and popular products
4. Use repository and service layers

📝 **Learning Focus:** Complex data modeling, hierarchical data, file management

---

### Problem 55: E-Commerce API - Part 2 (Shopping & Orders)

**Topics:** Transaction management, business logic

**Instructions:**
1. Implement shopping cart:
   - Add/remove/update items
   - Calculate totals (subtotal, tax, shipping)
   - Apply discount codes
   - Session-based for anonymous users, DB-based for authenticated
2. Implement order processing:
   - Create order from cart
   - Order status workflow (Pending → Processing → Shipped → Delivered)
   - Inventory deduction with transaction
   - Order history for users
3. Add background service for abandoned cart cleanup
4. Implement proper concurrency handling for inventory

📝 **Learning Focus:** Transaction management, state machines, business rules

---

### Problem 56: E-Commerce API - Part 3 (Reviews & Recommendations)

**Topics:** User-generated content, algorithms

**Instructions:**
1. Implement product reviews:
   - CRUD operations with ownership verification
   - Rating system (1-5 stars)
   - Review helpfulness votes
   - Image uploads for reviews
   - Moderation flags
2. Add recommendation system:
   - "Frequently bought together"
   - "Customers also viewed"
   - "Based on your history"
3. Implement review aggregation (average rating, count)
4. Add background service for calculating product ratings
5. Cache recommendations

📝 **Learning Focus:** User-generated content, aggregations, recommendation logic

---

### Problem 57: Task Management API - Part 1 (Core System)

**Topics:** Complex authorization, team collaboration

**Instructions:**
1. Design and implement:
   - Entities: Project, Task, User, Team, TaskComment, TaskAttachment
   - Team-based access control
   - Role-based permissions (Owner, Admin, Member, Viewer)
   - Task CRUD with authorization (only team members)
   - Task assignment and status tracking
   - Priority and deadline management
2. Implement custom authorization policies:
   - Must be team member to view
   - Must be assigned or admin to edit
   - Must be owner to delete project
3. Add file attachments to tasks

📝 **Learning Focus:** Complex authorization, team collaboration, resource ownership

---

### Problem 58: Task Management API - Part 2 (Advanced Features)

**Topics:** Real-time features simulation, notifications

**Instructions:**
1. Add advanced task features:
   - Task dependencies (blocking/blocked by)
   - Subtasks (parent-child tasks)
   - Time tracking (start/stop timer, manual entry)
   - Task templates
   - Bulk operations (update multiple tasks)
2. Implement activity feed:
   - Track all changes (who, what, when)
   - Filter by user, task, project
   - Pagination for feed
3. Add notification system:
   - Store notifications in database
   - Mark as read/unread
   - Different types (assignment, mention, deadline)
4. Background service for deadline reminders

📝 **Learning Focus:** Complex relationships, activity tracking, notification patterns

---

### Problem 59: Social Media API - Part 1 (User & Content)

**Topics:** Social features, content management

**Instructions:**
1. Design and implement:
   - Entities: User, Post, Comment, Like, Follow, Hashtag
   - User profiles with bio, avatar
   - Follow/Unfollow system
   - Post creation (text, images)
   - Like/Unlike posts and comments
   - Comment threading (replies to comments)
   - Hashtag extraction and linking
2. Implement feed generation:
   - User's own posts
   - Posts from followed users
   - Trending posts (based on likes and recency)
3. Add privacy settings (public/private accounts)
4. Implement blocked users functionality

📝 **Learning Focus:** Social graph modeling, content feeds, privacy controls

---

### Problem 60: Complete API - Integration & Deployment

**Topics:** Full-stack API with all best practices

**Instructions:**
1. Choose one of the previous projects (Blog, E-Commerce, or Task Management)
2. Add all production features:
   - Comprehensive logging (Serilog to file and console)
   - Distributed caching (Redis)
   - Background jobs (cleanup, notifications, calculations)
   - Rate limiting per endpoint
   - API versioning with documented changes
   - Health checks for all dependencies
   - Full Swagger documentation with examples
   - Unit tests for critical business logic
   - Integration tests for key endpoints
3. Add deployment preparation:
   - Environment-specific configurations
   - Connection string management
   - Secrets handling
   - Docker containerization (create Dockerfile)
   - Database migration scripts
4. Create comprehensive README with:
   - Setup instructions
   - API documentation
   - Architecture overview
   - Deployment guide

📝 **Learning Focus:** Production deployment, testing, documentation, DevOps basics

---

## 📊 Progress Tracking

**Level 1 (Fundamentals):** ✅✅✅✅✅✅✅☐☐☐ (7/10)  
**Level 2 (EF Core & DB):** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 3 (Auth & Security):** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 4 (Validation & Errors):** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 5 (Advanced Features):** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 6 (Real-World Projects):** ☐☐☐☐☐☐☐☐☐☐ (0/10)

**Total Progress:** 0/60

---

## 📚 Essential Reading Resources

### Official Microsoft Documentation
1. **ASP.NET Core Fundamentals**
   - https://learn.microsoft.com/en-us/aspnet/core/fundamentals/
   
2. **Entity Framework Core**
   - https://learn.microsoft.com/en-us/ef/core/

3. **Security & Authentication**
   - https://learn.microsoft.com/en-us/aspnet/core/security/

4. **Web API Best Practices**
   - https://learn.microsoft.com/en-us/aspnet/core/web-api/

### Recommended Books (Read specific chapters as needed)
1. **"ASP.NET Core in Action"** by Andrew Lock
   - Best for fundamentals and middleware
   
2. **"Entity Framework Core in Action"** by Jon P. Smith
   - Deep dive into EF Core patterns

3. **"Building Microservices with ASP.NET Core"** by Kevin Hoffman
   - Advanced patterns and architecture

### Useful Blog Resources
- Andrew Lock's Blog: https://andrewlock.net/
- Code Maze: https://code-maze.com/
- Milan Jovanović: https://www.milanjovanovic.tech/

---

## 🛠️ Tools & Setup Checklist

### Required Tools
- ✅ Visual Studio Code or Visual Studio 2022
- ✅ .NET 8 SDK
- ✅ SQL Server 2022 + SSMS
- ✅ Postman or Insomnia (API testing)
- ✅ Git & GitHub account
- ✅ Docker Desktop (for Level 5+)

### Recommended VS Code Extensions
- C# (Microsoft)
- C# Dev Kit
- REST Client
- SQLTools
- GitLens
- Docker
- Thunder Client (alternative to Postman)

### NuGet Packages to Know
```
// Core
Microsoft.AspNetCore.OpenApi
Swashbuckle.AspNetCore

// Database
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

// Authentication
Microsoft.AspNetCore.Authentication.JwtBearer
System.IdentityModel.Tokens.Jwt
BCrypt.Net-Next

// Validation
FluentValidation.AspNetCore

// Logging
Serilog.AspNetCore
Serilog.Sinks.Console
Serilog.Sinks.File

// Caching
Microsoft.Extensions.Caching.StackExchangeRedis

// Testing
xUnit
Moq
Microsoft.AspNetCore.Mvc.Testing
```

---

## 💡 Tips for Success

### For Each Problem:
1. **Read First** - Don't code immediately. Read docs and understand concepts
2. **Plan** - Sketch out models and endpoints before coding
3. **Test Thoroughly** - Test happy path AND error cases
4. **Git Commit** - Commit after each problem with clear message: "feat: Problem 15 - Many-to-Many relationships"
5. **Portfolio** - Add significant projects (51-60) to recurpixel.io

### Common Pitfalls to Avoid:
- ❌ Skipping database migrations (always create and apply them)
- ❌ Not testing with Postman (always verify endpoints work)
- ❌ Hardcoding values (use configuration)
- ❌ Ignoring async/await (always use async for I/O operations)
- ❌ Skipping error handling (every endpoint should handle errors)
- ❌ Not using DTOs (never expose entities directly)

### Code Quality Practices:
- ✅ Follow RESTful conventions
- ✅ Use meaningful variable/method names
- ✅ Add XML comments to public methods
- ✅ Keep controllers thin (business logic in services)
- ✅ Use dependency injection everywhere
- ✅ Return appropriate HTTP status codes
- ✅ Validate all inputs
- ✅ Log important operations

---

### GitHub Repository Structure:
```
aspnet-learning-journey/
├── Level-01-Fundamentals/
│   ├── Problem-01-HelloWorld/
│   ├── Problem-02-BasicController/
│   └── ...
├── Level-02-EFCore/
│   └── ...
├── Level-06-Projects/
│   ├── BlogAPI/          # Featured project 1
│   ├── ECommerceAPI/     # Featured project 2
│   └── TaskManagementAPI/
└── README.md             # Your learning journey overview
```

---


## 📝 Problem-Solving Template

For each problem, follow this structure in your code:

```csharp
// Program.cs comments
// Problem X: [Title]
// Topics: [List topics]
// Learning Focus: [What you're practicing]

// Your implementation...

// Notes:
// - What worked well
// - What was challenging
// - Key takeaways
// - Questions for further research
```

---

## ✅ Success Metrics

You're ready to apply for jobs when you have:
- ✅ Completed at least Problems 1-40
- ✅ 2-3 complete APIs on GitHub (from Level 6)
- ✅ All projects have README with setup instructions
- ✅ Code follows best practices (DI, async, error handling)
- ✅ Can explain your code and decisions in interviews
- ✅ Portfolio site showcases your best work

