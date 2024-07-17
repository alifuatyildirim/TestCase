using MapsterMapper;
using TestCase.Contract;
using TestCase.Contract.Command.Activity;
using TestCase.Domain.Entities;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base; 

namespace TestCase.Application.Strategy;

public abstract class ActivityStrategyService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;
    private readonly IActivityRepository activityRepository;

    protected ActivityStrategyService(IMapper mapper, IUserRepository userRepository, IActivityRepository activityRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
        this.activityRepository = activityRepository;
    }

    protected async Task<Guid> SaveUserAsync(CreateActivityCommand command, ITransactionScope? scope = null)
    {
        var user = mapper.Map<User>(command);
        return await this.userRepository.CreateAsync(user, scope);
    }

    protected async Task<GuidIdResult> SaveActivityAsync(CreateActivityCommand command, ITransactionScope? scope = null)
    {
        var activity = mapper.Map<Activity>(command);
        return new GuidIdResult(await this.activityRepository.CreateAsync(activity, scope));
    } 
}