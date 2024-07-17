using MongoDB.Driver; 

namespace TestCase.Data.Extensions;

public static class CreateIndexOptionsExtensions
{
    public static global::MongoDB.Driver.CreateIndexOptions<TEntity> ToMongoDBCreateIndexOptions<TEntity>(this CreateIndexOptions<TEntity> options)
    {
        return new global::MongoDB.Driver.CreateIndexOptions<TEntity>()
        {
            ExpireAfter = options.ExpireAfter,
            Name = options.Name,
            Unique = options.Unique,
            PartialFilterExpression = options.PartialFilterExpression,
        };
    }
}