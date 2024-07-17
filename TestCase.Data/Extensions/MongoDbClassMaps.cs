using MongoDB.Bson.Serialization;
using TestCase.Data.Repositories.MongoDb;

namespace TestCase.Data.Extensions;

public static class MongoDbClassMaps
{
    public static void Initialize()
    {
        AddSerializationProviders();
    } 
    private static void AddSerializationProviders()
    {
        BsonSerializer.RegisterSerializationProvider(new DecimalSerializationProvider());
    }
}