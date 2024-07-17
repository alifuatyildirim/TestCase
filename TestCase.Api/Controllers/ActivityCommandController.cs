using Microsoft.AspNetCore.Mvc;
using TestCase.Common.Mediatr.Command; 
using TestCase.Contract;
using TestCase.Contract.Command.Activity; 
namespace TestCase.Api.Controllers;

public class ActivityCommandController : ControllerBase
{
    private readonly IApplicationCommandSender commandSender;
    public ActivityCommandController(IApplicationCommandSender commandSender)
    {
        this.commandSender = commandSender;
    }

    [Route("activities")]
    [HttpPost]
    public async  Task<ApiResponse<GuidIdResult>> CreateActivities([FromBody]CreateActivityCommand command)
    { 
        return new ApiResponse<GuidIdResult>
        {
            Data = await this.commandSender.SendAsync(command),
        };
    } 
}