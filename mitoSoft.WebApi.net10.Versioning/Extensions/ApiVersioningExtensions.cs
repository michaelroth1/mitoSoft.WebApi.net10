using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.net10.Versioning.Extensions;

public static class ApiVersioningExtensions
{
    public static IServiceCollection AddNet10ApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}