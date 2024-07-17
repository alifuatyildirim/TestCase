using MongoDB.Driver;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Data.Repositories.MongoDb.Index;

internal class MongoDBIndexKeysDefinition<TEntity> : IIndexKeysDefinition<TEntity>
{
    internal MongoDBIndexKeysDefinition(IndexKeysDefinition<TEntity> indexKeysDefinition)
    {
        this.IndexKeysDefinition = indexKeysDefinition;
    }

    internal IndexKeysDefinition<TEntity> IndexKeysDefinition { get; }
}