# WebApi.net10.Swagger.Authentication

API-Key-Authentifizierung für ASP.NET Core Web APIs mit Swagger-Integration (.NET 10).

## Installation

```xml
<ProjectReference Include="..\WebApi.net10.Swagger.Authentication\WebApi.net10.Swagger.Authentication.csproj" />
```

## Konfiguration

### appsettings.json

```json
{
  "ApiKeys": {
    "ValidKeys": [
      "your-secret-api-key-1",
      "development-key-12345"
    ]
  }
}
```

### Program.cs

```csharp
using WebApi.net10.Swagger.Authentication.ApiKey;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerWithApiKey();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiKeyAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

## Verwendung

### API-Aufruf

```bash
curl -H "X-API-Key: your-secret-api-key-1" https://localhost:7170/api/weatherforecast
```

### Swagger UI

1. API starten und zu `/swagger` navigieren
2. Auf **"Authorize"** klicken
3. API-Key eingeben
4. Endpunkte testen

## Hinweise

- Swagger-Endpunkte sind von der Authentifizierung ausgenommen
- Verwenden Sie HTTPS in Produktion
- Für komplexere Szenarien OAuth2/JWT verwenden
