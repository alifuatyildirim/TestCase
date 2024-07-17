using TestCase.Application.Factory;
using TestCase.Application.Services.Abstraction;
using TestCase.Common.Mediatr.Command;
using TestCase.Contract;
using TestCase.Contract.Command.Activity;

namespace TestCase.Application.Handlers.Activity;

public class CreateActivityCommandHandler: IApplicationCommandHandler<CreateActivityCommand, GuidIdResult>
{
    private readonly IActivityStrategyFactory activityStrategyFactory;

    public CreateActivityCommandHandler( IActivityStrategyFactory activityStrategyFactory)
    {
        this.activityStrategyFactory = activityStrategyFactory;
    }

    public async Task<GuidIdResult> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        return await this.activityStrategyFactory.GetActivityStrategy(request.ActivityType).ExecuteAsync(request);
    }
}