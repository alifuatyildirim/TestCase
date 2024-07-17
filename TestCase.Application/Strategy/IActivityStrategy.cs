using TestCase.Contract;
using TestCase.Contract.Command.Activity;

namespace TestCase.Application.Strategy;

public interface IActivityStrategy 
{
    Task<GuidIdResult> ExecuteAsync(CreateActivityCommand command);
}