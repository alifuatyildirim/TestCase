using TestCase.Contract.Response.User;
using TestCase.Domain.Entities;

namespace TestCase.Application.Services.Abstraction;

public interface IUserService : IApplicationService
{
    Task<ActivityResponse> GetUserActivitiesAsync(Guid id, CancellationToken cancellationToken);
}