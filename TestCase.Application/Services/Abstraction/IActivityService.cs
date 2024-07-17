using TestCase.Contract;
using TestCase.Contract.Query.Activities;
using TestCase.Contract.Response.User;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Application.Services.Abstraction;

public interface IActivityService : IApplicationService
{
    Task<GuidIdResult> CreateActivity(Activity activity, ITransactionScope? scope = null);
    Task<ActivityResponse> GetUserActivitiesAsync(Guid id, CancellationToken cancellationToken);
    Task<AllActivityResponse> GetAllActivitiesAsync(GetAllActivitiesQuery query, CancellationToken cancellationToken);
}