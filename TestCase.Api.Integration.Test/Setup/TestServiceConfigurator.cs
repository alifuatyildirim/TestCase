using AdCodicem.SpecFlow.MicrosoftDependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TestCase.Api.Integration.Test.Setup.ServiceRegistration;
using TestCase.Application.Extensions.ServiceRegistration;
using TestCase.Data.Extensions;
using TestCase.Data.Repositories;
using TestCase.Data.Repositories.MongoDb;
using TestCase.Domain.Repositories;
using TestCase.Api.Integration.Test.Setup.Substitution;
using Xunit.Abstractions;

namespace TestCase.Api.Integration.Test.Setup
{
    public class TestServiceConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.SetDefaultConfiguration(Substitute.For<IConfiguration>()); 
            
            services
                .AddScoped<TestApplicationFactoryFixture>()
                .AddDelegated<ITestOutputHelper>()
                .AddSingleton(typeof(ILogger<>), typeof(SubstituteLogger<>))
                .AddMongoForTest()
                .AddCoreServices()
                .AddFixtures()
                .AddHttpContextAccessor();
        }
    }
}