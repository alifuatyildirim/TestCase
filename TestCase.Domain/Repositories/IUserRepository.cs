using TestCase.Common.Abstraction;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Domain.Repositories;

public interface IUserRepository : IRepository
{
    Task<Guid> CreateAsync(Entities.User user, ITransactionScope? scope = null);
    Task<Entities.User?> GetAsync(Guid id);

    Task<ITransactionScope> BeginTransactionScopeAsync();
}