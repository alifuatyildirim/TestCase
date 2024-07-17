using System.Linq.Expressions;
using TestCase.Common.Extensions;
using TestCase.Contract.Query.Activities;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly IGenericRepository<Activity, Guid> genericRepository;

    public ActivityRepository(IGenericRepository<Activity, Guid> genericRepository)
    {
        this.genericRepository = genericRepository;
        this.genericRepository.CreateCollection();
    }
    
    public async Task<Guid> CreateAsync(Activity activity, ITransactionScope? scope = null)
    {
        if (activity.Id == default)
        {
            activity.Id = Guid.NewGuid();
        }
        await this.genericRepository.AddOneAsync(activity,transactionScope:scope);
        return activity.Id;
    }

    public async Task<(IReadOnlyCollection<Activity>? items, int count)> GetUserActivities(Guid userId)
    {
       var allActivities = await this.genericRepository.Query().Where(x=>x.UserId == userId).ToListAsync();
       return (allActivities, allActivities.Count);
    }

    public async Task<IReadOnlyCollection<Activity>?> GetAllAsync(GetAllActivitiesQuery query)
    {
        IQueryBuilder<Activity> queryBuilder = this.genericRepository.Query();

        Expression<Func<Activity, bool>> condition =
            LinqExpressionBuilder.New<Activity>(x=>true);

        if (query.UserId is not null)
        {
            condition = condition.And(x => x.UserId == query.UserId);
        }

        if (query.ActivityType is not null)
        {
            condition = condition.And(x => x.ActivityType == query.ActivityType);
        }

        if (query.StartDate is not null)
        {
            condition = condition.And(x => x.ActivityTime >= query.StartDate.Value.Date);
        }

        if (query.EndDate is not null)
        {
            condition = condition.And(x => x.ActivityTime < query.EndDate.Value.Date.AddDays(1));
        }

        var filters = await queryBuilder.Where(condition).ToListAsync();
        return filters;
    }
}