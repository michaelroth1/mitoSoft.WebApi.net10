# mitoSoft.WebApi.net10

Helper libraries for building modern ASP.NET Core Web APIs with .NET 10. This repository contains reusable components that simplify common Web API scenarios.

## 📦 Packages

### 1. mitoSoft.WebApi.net10.Versioning
[![NuGet](https://img.shields.io/badge/nuget-v1.0.2-blue)](https://www.nuget.org/packages/mitoSoft.WebApi.net10.Versioning/)

API versioning support for ASP.NET Core Web APIs with seamless Swagger integration.

**Features:**
- ✅ URL-based API versioning (`/api/v1/`, `/api/v2/`)
- ✅ Automatic Swagger documentation per version
- ✅ Built on top of `Asp.Versioning.Mvc` (Microsoft Community Toolkit)
- ✅ Simple one-line configuration

**Installation:**
```bash
dotnet add package mitoSoft.WebApi.net10.Versioning
```

**Quick Start:**
```csharp
// Program.cs
using WebApi.net10.Versioning.Extensions;

builder.Services.AddNet10ApiVersioning();

// Controller
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase { }
```

[📖 Full Documentation](mitoSoft.WebApi.net10.Versioning/README.md)

---

### 2. mitoSoft.WebApi.net10.Swagger.Authentication.ApiKey
[![NuGet](https://img.shields.io/badge/nuget-v1.0.2-blue)](https://www.nuget.org/packages/mitoSoft.WebApi.net10.Swagger.Authentication.ApiKey/)

API Key authentication middleware with Swagger/OpenAPI integration.

**Features:**
- ✅ Header-based API Key authentication
- ✅ Swagger UI "Authorize" button support
- ✅ Configurable valid keys via `appsettings.json`
- ✅ Middleware-based authentication pipeline

**Installation:**
```bash
dotnet add package mitoSoft.WebApi.net10.Swagger.Authentication.ApiKey
```

**Quick Start:**
```csharp
// appsettings.json
{
  "ApiKeys": {
    "ValidKeys": [ "your-secret-key" ]
  }
}

// Program.cs
using WebApi.net10.Swagger.Authentication.ApiKey;

builder.Services.AddSwaggerWithApiKey();
app.UseApiKeyAuthentication();
```

[📖 Full Documentation](mitoSoft.WebApi.net10.Swagger.Authentication.ApiKey/README.md)

---

## 🚀 Demo Project

The repository includes a full demo WebAPI project (`WebApi`) showcasing both libraries working together:

```bash
git clone https://github.com/michaelroth1/mitoSoft.WebApi.net10.git
cd mitoSoft.WebApi.net10/WebApi
dotnet run
```

Navigate to: `https://localhost:7001/swagger`

---

## 🌐 API Gateway Example

The repository also includes an **API Gateway** example using **YARP** (Yet Another Reverse Proxy) for hosting multiple APIs on the same port with path-based routing:

```
Gateway (Port 5024)
├── /WebApi1/* → WebApi (Port 7001)
└── /WebApi2/* → WebApi2 (Port 7106)
```

**Run all projects:**
1. Set multiple startup projects: `ApiGateway`, `WebApi`, `WebApi2`
2. Press F5
3. Access via Gateway: `https://localhost:7170/WebApi1/swagger`

---

## 🎯 Why These Libraries?

### Purpose
These libraries simplify common patterns when building Web APIs with .NET 10:

1. **API Versioning** - Essential for maintaining backwards compatibility as your API evolves
2. **API Key Authentication** - Quick and simple authentication for development, testing, or internal APIs

### Benefits
- 🔧 **Zero boilerplate** - Single-line service registration
- 📚 **Swagger integration** - Works seamlessly with OpenAPI documentation
- 🎨 **Best practices** - Built on top of official Microsoft libraries
- ⚡ **Production-ready** - Used in real-world projects

---

## 🛠️ Requirements

- **.NET 10 SDK** or later
- **ASP.NET Core 10** or later

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Author

**mitoSoft** - [GitHub](https://github.com/michaelroth1)

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📮 Support

If you have any questions or need help, please open an issue on GitHub.

---

## ⭐ Show your support

Give a ⭐️ if this project helped you!
