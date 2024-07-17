using MongoDB.Driver;
using TestCase.Domain.Entities.BaseEntity;

namespace TestCase.Domain.Repositories.Base;

public interface IGenericRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : IEquatable<TId>
{ 
 
    bool CreateCollection();   

    IQueryBuilder<TEntity> Query();

    Task<TEntity> GetByIdAsync(TId id);

    Task<ITransactionScope> BeginTransactionScopeAsync();
    
    IIndexKeysDefinitionBuilder<TEntity> IndexKeys { get; }

    void CreateIndex(IIndexKeysDefinition<TEntity> indexKeysDefinition, CreateIndexOptions<TEntity> createIndexOptions);

    Task AddOneAsync(TEntity entity, ITransactionScope? transactionScope = null);

    Task UpdateAsync(TEntity entity, ITransactionScope? transactionScope = null);
}