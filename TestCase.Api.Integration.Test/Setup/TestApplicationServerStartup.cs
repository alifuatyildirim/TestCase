using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using TestCase.Api.Attributes;
using TestCase.Api.Extensions;
using TestCase.Api.Integration.Test.Setup.ServiceRegistration;
using TestCase.Application.Extensions.ServiceRegistration;
using TestCase.Application.Services.Abstraction;
using TestCase.Common.Mediatr.Mediator;
using TestCase.Data.Repositories.MongoDb;

namespace TestCase.Api.Integration.Test.Setup
{ 
    public class TestApplicationServerStartup
    { 
        public void ConfigureServices(IServiceCollection services)
        { 
            services.SetDefaultConfiguration(Substitute.For<IConfiguration>());

            services.AddControllers(config => config.Filters.Add(new FromBodyFilterAttribute()))
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = false;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                    options.ClientErrorMapping[404].Link =
                        "https://httpstatuses.com/404";
                });
            
            services.AddHttpContextAccessor();

            IEnumerable<Assembly> assemblies = new List<Assembly>
            {
                Assembly.GetAssembly(typeof(IApplicationService))!,
            };

            services.AddCqrsMediator(assemblies)
                .AddApplicationServices()
                .AddMongoForTest()
                .AddCoreServices();
 

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddApplicationPart(typeof(Api.Startup).Assembly)
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
                
            app.UseTestCaseMiddlewares();
            
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}