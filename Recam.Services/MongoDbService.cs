using MongoDB.Driver;
using Recam.Common;

namespace Recam.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}