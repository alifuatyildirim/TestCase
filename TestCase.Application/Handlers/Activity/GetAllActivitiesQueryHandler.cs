using TestCase.Application.Services.Abstraction;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract.Query.Activities;
using TestCase.Contract.Response.User;

namespace TestCase.Application.Handlers.Activity;

public class GetAllActivitiesQueryHandler : IQueryHandler<GetAllActivitiesQuery, AllActivityResponse>
{

    private readonly IActivityService activityService;
    public GetAllActivitiesQueryHandler(IActivityService activityService)
    {
        this.activityService = activityService;
    }
    public async Task<AllActivityResponse> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await this.activityService.GetAllActivitiesAsync(request, cancellationToken);
    }
}