using System.Reflection;
using TestCase.Application.Extensions.ServiceRegistration;
using TestCase.Application.Services.Abstraction;
using TestCase.Common.Mediatr.Mediator;
using TestCase.Data.Extensions;
using TestCase.Data.Repositories.MongoDb;
using TestCase.Api.Middlewares;
using TestCase.Application.Factory;
using TestCase.Application.Strategy; 

namespace TestCase.Api.Extensions;

public static class StartupExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddSwaggerGen(c => c.SwaggerGenSetup(env.EnvironmentName, env.ApplicationName))
            .AddSwaggerGenNewtonsoftSupport();

        return services;
    }

    public static IServiceCollection AddTestCaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        IEnumerable<Assembly> assemblies = new List<Assembly>
        {
            Assembly.GetAssembly(typeof(IApplicationService))!
        };

        services.SetDefaultConfiguration(configuration)
            .AddCqrsMediator(assemblies)
            .AddApplicationServices()
            .AddCoreServices()
            .AddMongoDb();

        services.AddScoped<SignupActivityStrategy>()
            .AddScoped<DefaultActivityStrategy>()
            .AddScoped<IActivityStrategyFactory, ActivityStrategyFactory>();

        return services;
    }

    public static IApplicationBuilder UseSwaggerWithUi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{env.ApplicationName} V1");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = $"{env.ApplicationName} ({env.EnvironmentName})";
            });
        return app;
    }

    public static IApplicationBuilder UseTestCaseMiddlewares(this IApplicationBuilder app)
    { 
        app.UseMiddleware<HttpLoggingMiddleware>()
            .UseMiddleware<ExceptionHandlerMiddleware>();

        return app;
    } 
}