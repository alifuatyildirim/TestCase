using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestCase.Api.Integration.Test.Extensions;
using TestCase.Api.Integration.Test.Setup; 
using TestCase.Api.Integration.Test.Tests.User.Steps.TestModels;
using TestCase.Contract.Command.Activity;

namespace TestCase.Api.Integration.Test.Tests.User.Steps
{
    [Binding]
    public class UserStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly UserFixture userFixture;
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;
 
        private IReadOnlyList<TestCase.Domain.Entities.User>? users; 

        public UserStepDefinitions(
            ScenarioContext scenarioContext,
            UserFixture userFixture,
            TestApplicationFactoryFixture webApplicationFactory,
            IMapper mapper)
        {
            this.scenarioContext = scenarioContext;
            this.userFixture = userFixture;
            this.mapper = mapper;

            this.httpClient = webApplicationFactory.CreateHttpClient(
                services =>
                { 
                    services.AddScoped(_ => this.userFixture.UserRepository);
                });
        }
        
        [Given("Users are")]
        public async Task GivenUsersAre(Table table)
        {
            this.users = (IReadOnlyList<TestCase.Domain.Entities.User>)table.CreateSet<TestCase.Domain.Entities.User>();
            this.users.AssertNotNull();
            foreach (var user in users)
            {
                await this.userFixture.UserRepository.CreateAsync(user);
            }
        }
 
        [When(@"POST ""/activities"" is called with parameters")]
        public async Task WhenCreateActivitiesCommandEndpointIsCalledWithParametersAsync(Table table)
        {
            CreateActivityCommand request = table.CreateInstance<CreateActivityCommand>();
            string endpoint = $"/activities";
            await this.httpClient.CallEndpointAsync<CreateActivityCommand>(HttpMethod.Post, endpoint, request, this.scenarioContext);
        }
        
        
        [Then(@"Users should be")]
        public async Task ThenUsersShouldBeAsync(Table table)
        {
            List<TestCase.Domain.Entities.User> userResult  = (await this.userFixture.UserRepositoryForTest.GetAllAsync()).OrderBy(x=>x.Name).ToList();
            table.CompareToSet(this.mapper.Map<List<UserTestModel>>(userResult), true); 
        } 
        
    }
}