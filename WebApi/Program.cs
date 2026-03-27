using WebApi.net10.Swagger.Authentication.ApiKey;
using WebApi.net10.Versioning.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// API Versioning
builder.Services.AddNet10ApiVersioning();

builder.Services.AddSwaggerWithApiKey();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "WebApi2 - API",
        Version = "v1",
        Description = "Eine ASP.NET Core Web API für .NET 10 - Version 1"
    });

    options.SwaggerDoc("v2", new()
    {
        Title = "WebApi2 - API",
        Version = "v2",
        Description = "Eine ASP.NET Core Web API für .NET 10 - Version 2 (mit erweiterten Features)"
    });

    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        return apiDesc.GroupName == docName;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
}

app.UseApiKeyAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
