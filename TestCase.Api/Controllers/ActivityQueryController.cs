using Microsoft.AspNetCore.Mvc;
using TestCase.Common.Mediatr.Command;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract;
using TestCase.Contract.Query.Activities;
using TestCase.Contract.Query.User;
using TestCase.Contract.Response.User;

namespace TestCase.Api.Controllers;

public class ActivityQueryController : ControllerBase
{
    private readonly IQueryProcessor queryProcessor; 
        
    public ActivityQueryController(IQueryProcessor queryProcessor)
    { 
        this.queryProcessor = queryProcessor;
    }
    [Route("activities")]
    [HttpGet]
    public async  Task<ApiResponse<AllActivityResponse>> GetActivities(GetAllActivitiesQuery query)
    { 
        return new ApiResponse<AllActivityResponse>
        {
            Data = await this.queryProcessor.ProcessAsync(query),
        };
    } 
}