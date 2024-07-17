using TestCase.Domain.Entities;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Data.Repositories;

public class UserRepository : IUserRepository,IUserRepositoryForTest
{
    private readonly IGenericRepository<User, Guid> genericRepository;

    public UserRepository(IGenericRepository<User, Guid> genericRepository)
    {
        this.genericRepository = genericRepository;
        this.genericRepository.CreateCollection();
    }
    
    public async Task<Guid> CreateAsync(User user, ITransactionScope? scope=null)
    {
        if (user.Id == default)
        {
            user.Id = Guid.NewGuid();
        }
        await this.genericRepository.AddOneAsync(user,transactionScope:scope);
        return user.Id;
    }

    public async Task UpdateAsync(User user, ITransactionScope? scope = null)
    {
        await this.genericRepository.UpdateAsync(user,scope);
    } 
    
    public async Task<User?> GetAsync(Guid id)
    {
        return await this.genericRepository.GetByIdAsync(id);
    }

    public async Task<ITransactionScope> BeginTransactionScopeAsync()
    {
        return await this.genericRepository.BeginTransactionScopeAsync();
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        return await this.genericRepository.Query().ToListAsync();
    }
}