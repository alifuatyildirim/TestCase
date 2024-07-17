using Microsoft.AspNetCore.Mvc;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract;
using TestCase.Contract.Query.User;
using TestCase.Contract.Response.User;

namespace TestCase.Api.Controllers;

public class UserQueryController : ControllerBase
{
    private readonly IQueryProcessor queryProcessor; 
        
    public UserQueryController(IQueryProcessor queryProcessor)
    { 
        this.queryProcessor = queryProcessor;
    }
    [Route("user/{id}/activities")]
    [HttpGet]
    public async  Task<ApiResponse<ActivityResponse>> GetUser(Guid id)
    { 
        return new ApiResponse<ActivityResponse>
        {
            Data = await this.queryProcessor.ProcessAsync(new GetUserActivitiesQuery()
            {
                Id = id
            }),
        };
    } 
}