using TestCase.Application.Services.Abstraction;
using TestCase.Common.Mediatr.Query;
using TestCase.Contract.Query.User;
using TestCase.Contract.Response.User;

namespace TestCase.Application.Handlers.User;

public class GetUserActivitiesQueryHandler : IQueryHandler<GetUserActivitiesQuery, ActivityResponse>
{

    private readonly IActivityService activityService;
    public GetUserActivitiesQueryHandler(IActivityService activityService)
    {
        this.activityService = activityService;
    }
    public async Task<ActivityResponse> Handle(GetUserActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await this.activityService.GetUserActivitiesAsync(request.Id, cancellationToken);
    }
}