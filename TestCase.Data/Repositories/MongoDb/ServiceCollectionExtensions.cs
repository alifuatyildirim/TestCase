using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Pluralize.NET;
using TestCase.Domain.Repositories;
using TestCase.Domain.Repositories.Base;
using TestCase.Data.Repositories.MongoDb.Index;

namespace TestCase.Data.Repositories.MongoDb;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDBRepository(this IServiceCollection services)
    {
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        BsonSerializer.RegisterSerializationProvider(new DecimalSerializationProvider()); 

        services.AddNewtonsoftJsonCoreSettings();

        return services.AddSingleton<IDatabaseConnection, MongoDBDatabaseConnection>()
            .AddSingleton(typeof(IGenericRepository<,>), typeof(MongoDBGenericRepository<,>))
            .AddSingleton(typeof(IIndexKeysDefinitionBuilder<>), typeof(MongoDBIndexKeysDefinitionBuilder<>))
            .AddSingleton<IPluralize, Pluralizer>()
            .ConfigureWithOptionName<MongoDBOptions>();
    }
 
}