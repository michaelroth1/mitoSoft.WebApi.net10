using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SWebApi.net10.Swagger.Authentication.Middleware;

namespace WebApi.net10.Swagger.Authentication.ApiKey;

public static class SwaggerApiKeyExtensions
{
    /// <summary>
    /// Adds Swagger with API Key authentication support
    /// </summary>
    public static IServiceCollection AddSwaggerWithApiKey(this IServiceCollection services, string securityDefinitionName = "ApiKey")
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(securityDefinitionName, new Microsoft.OpenApi.OpenApiSecurityScheme
            {
                Name = "X-API-Key",
                Type = Microsoft.OpenApi.SecuritySchemeType.ApiKey,
                In = Microsoft.OpenApi.ParameterLocation.Header,
                Description = "API Key authentication. Enter your API Key in the value field."
            });

            options.AddSecurityRequirement(document =>
            {
                var requirement = new Microsoft.OpenApi.OpenApiSecurityRequirement();
                var schemeRef = new Microsoft.OpenApi.OpenApiSecuritySchemeReference(securityDefinitionName, document, null);
                requirement.Add(schemeRef, new List<string>());
                return requirement;
            });
        });

        return services;
    }

    /// <summary>
    /// Adds API Key middleware to the pipeline
    /// </summary>
    public static IApplicationBuilder UseApiKeyAuthentication(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ApiKeyMiddleware>();
    }
}