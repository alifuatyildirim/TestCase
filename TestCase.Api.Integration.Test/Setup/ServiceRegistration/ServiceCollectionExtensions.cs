using Microsoft.Extensions.DependencyInjection; 
using Pluralize.NET; 
using TestCase.Data.Repositories;
using TestCase.Data.Repositories.MongoDb;
using TestCase.Data.Repositories.MongoDb.Index;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;
using TestCase.Api.Integration.Test.Tests.User;
using TestCase.Application.Factory;
using TestCase.Application.Strategy;

namespace TestCase.Api.Integration.Test.Setup.ServiceRegistration
{
    public static class ServiceCollectionExtensions
    {  
        public static IServiceCollection AddMongoForTest(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnection, MongoDBTestDatabaseConnection>()
                .AddSingleton(typeof(IGenericRepository<,>), typeof(MongoDBGenericRepository<,>))
                .AddSingleton(typeof(IIndexKeysDefinitionBuilder<>), typeof(MongoDBIndexKeysDefinitionBuilder<>))
                .AddSingleton<IPluralize, Pluralizer>();

            services.Configure<MongoDBOptions>(x =>
            {
                ServiceProvider sp = services.BuildServiceProvider();
                Mongo2GoFixture? fixture = sp.GetService<Mongo2GoFixture>();
                x.Database = fixture?.MongoDatabaseName;
                x.ConnectionString = fixture?.MongoConnectionString;
            });

            services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IActivityRepository, ActivityRepository>()
                .AddSingleton<IUserRepositoryForTest, UserRepository>();
            
            services.AddScoped<SignupActivityStrategy>()
                .AddScoped<DefaultActivityStrategy>()
                .AddScoped<IActivityStrategyFactory, ActivityStrategyFactory>();
            return services;
        }

        public static IServiceCollection AddFixtures(this IServiceCollection services)
        {
            return services
                .AddScoped<UserFixture>()
                .AddSingleton<Mongo2GoFixture>();
        }
 
    }
}