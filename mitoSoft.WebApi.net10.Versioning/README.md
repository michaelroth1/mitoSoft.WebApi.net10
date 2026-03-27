# WebApi.net10.Versioning

API-Versionierung für ASP.NET Core Web APIs mit Swagger-Integration (.NET 10).

## Installation

```xml
<ProjectReference Include="..\WebApi.net10.Versioning\WebApi.net10.Versioning.csproj" />
```

## Konfiguration

### Program.cs

```csharp
using WebApi.net10.Versioning.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddNet10ApiVersioning();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

## Verwendung

### Controller mit Version

```csharp
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Version 1.0");
        }
    }
}
```

### Mehrere Versionen

```csharp
namespace MyApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] int days = 7)
        {
            return Ok(new { Version = "2.0", Days = days });
        }
    }
}
```

## API-Aufrufe

```bash
# Version 1.0
curl https://localhost:7170/api/v1/weatherforecast

# Version 2.0
curl https://localhost:7170/api/v2/weatherforecast?days=10
```

## Swagger UI

Die Swagger UI zeigt automatisch alle API-Versionen in separaten Dokumenten:
- `/swagger/v1/swagger.json`
- `/swagger/v2/swagger.json`

Wählen Sie die gewünschte Version im Dropdown oben rechts in der Swagger UI.

## Standardeinstellungen

- **Default Version**: 1.0
- **AssumeDefaultVersionWhenUnspecified**: true (unversionierte Requests verwenden Default)
- **ReportApiVersions**: true (API-Versionen werden im Response-Header zurückgegeben)
- **URL-Format**: `v{version}` (z.B. `v1`, `v2`)
