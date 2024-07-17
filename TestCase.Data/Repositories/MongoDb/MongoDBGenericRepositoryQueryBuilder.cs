using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;

namespace TestCase.Data.Repositories.MongoDb;

internal class MongoDBGenericRepositoryQueryBuilder<T> : IQueryBuilder<T>
    where T : notnull
{
    private IMongoQueryable<T> mongoQueryable;

    internal MongoDBGenericRepositoryQueryBuilder(IMongoQueryable<T> mongoQueryable)
    {
        this.mongoQueryable = mongoQueryable;
    }

    public async Task<IReadOnlyList<T>> ToListAsync()
    {
        return await this.mongoQueryable.ToListAsync();
    }

    public IQueryBuilder<T> Where(Expression<Func<T, bool>> predicate)
    {
        this.mongoQueryable = this.mongoQueryable.Where(predicate);
        return this;
    }
    
    public async Task<bool> Any(Expression<Func<T, bool>> predicate)
    {
         return await this.mongoQueryable.AnyAsync(predicate); 
    }
    
    public async Task<T?> FirstOrDefaultAsync() => await this.mongoQueryable.FirstOrDefaultAsync<T>();
}