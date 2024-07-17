using TestCase.Common.Abstraction; 

namespace TestCase.Domain.Repositories;

public interface IUserRepositoryForTest : IRepository
{
    Task<IReadOnlyList<Entities.User>> GetAllAsync();
}