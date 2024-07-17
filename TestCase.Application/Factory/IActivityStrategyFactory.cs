using TestCase.Application.Services.Abstraction;
using TestCase.Application.Strategy;
using TestCase.Common;

namespace TestCase.Application.Factory;

public interface IActivityStrategyFactory
{
    IActivityStrategy GetActivityStrategy(ActivityType activityType);
}