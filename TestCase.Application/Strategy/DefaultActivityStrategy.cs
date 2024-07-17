using MapsterMapper;
using TestCase.Contract;
using TestCase.Contract.Command.Activity;
using TestCase.Domain.Repositories;

namespace TestCase.Application.Strategy;

public class DefaultActivityStrategy : ActivityStrategyService, IActivityStrategy
{
    public DefaultActivityStrategy(IUserRepository userRepository, IActivityRepository activityRepository, IMapper mapper) : base( mapper, userRepository, activityRepository )
    {
        
    }

    public async Task<GuidIdResult> ExecuteAsync(CreateActivityCommand command)
    {
        var result = await this.SaveActivityAsync(command);
        return result;
    }
}