using MongoDB.Driver;

namespace TestCase.Domain.Repositories.Base;

public interface IDatabaseConnection
{
    Task SaveChangesAsync();
    MongoClient GetClient();
    Task<ITransactionScope> BeginTransactionScopeAsync();

    ITransactionScope BeginTransactionScope();
}