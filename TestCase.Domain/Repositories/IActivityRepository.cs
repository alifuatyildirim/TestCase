using TestCase.Common.Abstraction;
using TestCase.Contract.Query.Activities;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Domain.Repositories;

public interface IActivityRepository : IRepository
{
    Task<Guid> CreateAsync(Activity activity, ITransactionScope? scope);
    Task<(IReadOnlyCollection<Activity>? items, int count)> GetUserActivities(Guid userId);
    Task<IReadOnlyCollection<Activity>?> GetAllAsync(GetAllActivitiesQuery query);
}