using Microsoft.Extensions.Options;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Data.Repositories.MongoDb;
public class MongoDBTestDatabaseConnection : MongoDBDatabaseConnection
{
    public MongoDBTestDatabaseConnection(IOptions<MongoDBOptions> options)
        : base(options)
    {
    }
        
    public override Task<ITransactionScope> BeginTransactionScopeAsync()
    {
        return Task.FromResult((ITransactionScope)new MongoDBTestTransactionScope());
    }

    public override ITransactionScope BeginTransactionScope()
    {
        return new MongoDBTestTransactionScope();
    }
}