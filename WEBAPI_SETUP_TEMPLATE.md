# .NET 10 WebAPI with Swagger - Setup Template

## Overview
This template provides the standard configuration for creating an ASP.NET Core WebAPI with .NET 10 and Swagger documentation.

---

## Requirements

### Framework & Language
- **.NET Version:** 10
- **C# Version:** 14.0
- **Project Type:** ASP.NET Core WebAPI

### Core Features
- Swagger/OpenAPI integration
- Controller-based API
- HTTPS redirection
- Authorization support

---

## Project Structure

### Service Registration
The following services should be registered in `Program.cs`:
- `AddControllers()`
- `AddOpenApi()`
- `AddEndpointsApiExplorer()`
- `AddSwaggerGen()` with configuration

### Middleware Pipeline
Configure the HTTP request pipeline in this order:
1. `UseSwagger()`
2. `UseSwaggerUI()` with relative paths
3. `UseHttpsRedirection()`
4. `UseAuthorization()`
5. `MapControllers()`

---

## Swagger Configuration

### Basic Settings
| Setting | Value |
|---------|-------|
| **Title** | English (e.g., "WebApi - API") |
| **Version** | "v1" |
| **Description** | English (e.g., "An ASP.NET Core Web API for .NET 10") |

### Important Configuration Details
- **Swagger Availability:** Enable in **all environments** (Development and Production)
- **Endpoint Paths:** Use **relative paths without leading slash**
  - Example: `../swagger/v1/swagger.json`
  - ❌ Wrong: `/swagger/v1/swagger.json`
  - ✅ Correct: `../swagger/v1/swagger.json`

---

## Code Template

### Program.cs

```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "WebApi - API",
        Version = "v1",
        Description = "An ASP.NET Core Web API for .NET 10"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // Use relative paths without leading slash
    options.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### Example Controller

```csharp
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly ILogger<ExampleController> _logger;

    public ExampleController(ILogger<ExampleController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets a sample message
    /// </summary>
    /// <returns>A sample message</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Get()
    {
        return Ok("Hello from .NET 10 WebAPI!");
    }

    /// <summary>
    /// Gets a message by ID
    /// </summary>
    /// <param name="id">The message ID</param>
    /// <returns>A message for the specified ID</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<string> GetById(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }

        return Ok($"Message with ID: {id}");
    }
}
```

---

## Code Conventions
- ✅ English comments and documentation
- ✅ XML documentation comments for controller actions
- ✅ Use `ProducesResponseType` attributes
- ✅ Remove default `WeatherForecast` controller
- ✅ Attribute-based routing: `[Route("api/[controller]")]`

## Extensions
This template can be extended with:
- API Versioning (v1, v2, etc.)
- Authentication (API Key, JWT, OAuth)
- CORS, Rate Limiting, Health Checks
- Database integration (EF Core)

## Quick Start
1. Create new .NET 10 WebAPI project
2. Configure `Program.cs` according to template
3. Remove `WeatherForecast` controller
4. Configure SwaggerUI with relative paths: `../swagger/v1/swagger.json`
5. Test at: `https://localhost:<port>/swagger`

---

## Copilot Prompt (Copy & Paste)

Use this prompt to set up the entire WebAPI project automatically:

```
Configure a .NET ASP.NET Core WebAPI project with Swagger UI:
(Code conventions: English comments, C# 14.0 features)

1. Install Swashbuckle.AspNetCore NuGet package

2. Configure in Program.cs:
   - AddSwaggerGen with SwaggerDoc "v1" (Title: "WebApi - API", Version: "v1", Description: "An ASP.NET Core Web API for .NET 10")
   - IMPORTANT: Use target-typed new() for OpenApiInfo instead of explicit type
   - UseSwagger and UseSwaggerUI in ALL environments (no Development check)
   - SwaggerUI Endpoint: "../swagger/v1/swagger.json" with name "API V1"
   - Ensure: AddControllers, AddOpenApi, AddEndpointsApiExplorer, UseHttpsRedirection, UseAuthorization, MapControllers

3. Remove WeatherForecast controller and model

4. Create ExampleController (Route: "api/[controller]") with:
   - Get() and GetById(int id) methods
   - XML documentation comments
   - ProducesResponseType attributes
   - IActionResult return type
   - ILogger injection

5. LaunchSettings: launchBrowser: true, launchUrl: "swagger"

```

---

**Last Updated:** [Date]
