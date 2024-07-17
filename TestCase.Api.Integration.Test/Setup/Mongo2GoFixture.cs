using System;

namespace TestCase.Api.Integration.Test.Setup
{
    public class Mongo2GoFixture
    {
        private readonly string databaseName = $"test-database-{Guid.NewGuid()}";

        public Mongo2GoFixture()
        {
            this.MongoConnectionString = MongoDbServer.ConnectionString;
            this.MongoDatabaseName = this.databaseName;
        }

        public string MongoConnectionString { get; }

        public string MongoDatabaseName { get; }
    }
}