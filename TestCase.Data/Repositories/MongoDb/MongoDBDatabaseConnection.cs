using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;
using TestCase.Data.Repositories.MongoDb;
using TestCase.Domain.Repositories.Base;

public class MongoDBDatabaseConnection : IDatabaseConnection
{
    public MongoDBDatabaseConnection(IOptions<MongoDBOptions> options)
    {
        MongoClientSettings clientSettings = MongoClientSettings.FromConnectionString(options.Value.ConnectionString);
        if (options.Value.ActivateSubscriber ?? false)
        {
            clientSettings.ClusterConfigurator = cb => cb.Subscribe(new DiagnosticsActivityEventSubscriber());
        }

        this.Client = new MongoClient(clientSettings);
        this.Database = this.Client.GetDatabase(options.Value.Database);
    }

    MongoClient Client { get; }

    internal IMongoDatabase Database { get; }

    public IClientSessionHandle Session { get; set; }

    public MongoClient GetClient()
    {
        return this.Client;
    }

    public virtual async Task<ITransactionScope> BeginTransactionScopeAsync()
    {
        Session = await this.Client.StartSessionAsync();
        Session.StartTransaction(); // İşlemi başlat
        return new MongoDBTransactionScope(this, Session);
    }

    public async Task SaveChangesAsync()
    {
        if (Session != null)
        {
            await Session.CommitTransactionAsync(); // İşlemi tamamla
        }
    }

    public virtual ITransactionScope BeginTransactionScope()
    {
        Session = this.Client.StartSession();
        Session.StartTransaction(); // İşlemi başlat
        return new MongoDBTransactionScope(this, Session);
    }
}