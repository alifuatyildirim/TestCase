using MapsterMapper;
using TestCase.Contract;
using TestCase.Contract.Command.Activity;
using TestCase.Domain.Repositories;

namespace TestCase.Application.Strategy;

public class SignupActivityStrategy : ActivityStrategyService, IActivityStrategy
{
    private readonly IUserRepository userRepository;
    public SignupActivityStrategy(IUserRepository userRepository, IActivityRepository activityRepository, IMapper mapper) : base( mapper, userRepository, activityRepository )
    {
        this.userRepository = userRepository;
    }

    public async Task<GuidIdResult> ExecuteAsync(CreateActivityCommand command)
    {
        var scope = await this.userRepository.BeginTransactionScopeAsync();
        
        command.UserId = await this.SaveUserAsync(command,scope);
        var result = await this.SaveActivityAsync(command,scope);
        
        await scope.CommitTransactionAsync();
        return result;
    }
}