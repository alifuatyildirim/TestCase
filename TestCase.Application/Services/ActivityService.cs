using System.Net;
using MapsterMapper;
using TestCase.Common.Codes;
using TestCase.Common.ExceptionHandling;
using TestCase.Common.Extensions;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories;
using TestCase.Application.Services.Abstraction;
using TestCase.Contract;
using TestCase.Contract.Query.Activities;
using TestCase.Contract.Response.User;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Application.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository activityRepository;
    private readonly IMapper mapper;

    public ActivityService(IActivityRepository activityRepository,IMapper mapper)
    {
        this.activityRepository = activityRepository;
        this.mapper = mapper;
    }

    public async Task<GuidIdResult> CreateActivity(Activity activity, ITransactionScope? scope = null)
    {
        return new GuidIdResult(await this.activityRepository.CreateAsync(activity, scope));
    }

    public async Task<ActivityResponse> GetUserActivitiesAsync(Guid id, CancellationToken cancellationToken)
    {
        (IReadOnlyCollection<Activity>? activities, int count) = await this.activityRepository.GetUserActivities(id);
        
        if (activities is null)
        {
            throw new TestCaseException(ErrorCode.InvalidUserId,
                ErrorCode.InvalidUserId.GetDescription(), HttpStatusCode.NotFound);
        }

        return new ActivityResponse()
        {
            UserId = id,
            Rows = this.mapper.Map<IReadOnlyList<ActivityResponseItem>>(activities.OrderBy(x=>x.ActivityTime)),
            TotalCount = count
        };
    }

    public async Task<AllActivityResponse> GetAllActivitiesAsync(GetAllActivitiesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Activity>? activities = await this.activityRepository.GetAllAsync(query);
        
        var grouped = activities?.GroupBy(x => x.UserId).Select(x => new ActivityResponse
        {
            UserId = x.Key,
            Rows = x.Select(a => new ActivityResponseItem
            {
                ActivityType = a.ActivityType,
                Description = a.Description,
                ActivityId = a.Id,
                ActivityTime = a.ActivityTime
            }).OrderBy(x=>x.ActivityTime).ToList(),
            TotalCount = x.Count()
        }).ToList();

        return new AllActivityResponse()
        {
            Rows = grouped,
            TotalCount = grouped?.Count ?? 0
        };

    }
}