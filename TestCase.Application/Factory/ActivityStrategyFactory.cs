using TestCase.Application.Strategy;
using TestCase.Common;
using TestCase.Contract.Command.Activity;

namespace TestCase.Application.Factory;

public class ActivityStrategyFactory : IActivityStrategyFactory
{
    private readonly SignupActivityStrategy signupActivityStrategy;
    private readonly DefaultActivityStrategy defaultActivityStrategy;

    public ActivityStrategyFactory(SignupActivityStrategy signupActivityStrategy, DefaultActivityStrategy defaultActivityStrategy)
    {
        this.signupActivityStrategy = signupActivityStrategy;
        this.defaultActivityStrategy = defaultActivityStrategy;
    }
    public IActivityStrategy GetActivityStrategy(ActivityType activityType)
    {
        switch (activityType)
        {
            case ActivityType.Signup:
                return this.signupActivityStrategy;
            case ActivityType.Login:
            case ActivityType.PageView:
            case ActivityType.Other:
                return this.defaultActivityStrategy;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}