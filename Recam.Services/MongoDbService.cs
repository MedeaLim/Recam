using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Recam.Common;

namespace Recam.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;

    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
        var mongoSettings = settings.Value;

        var client = new MongoClient(mongoSettings.ConnectionString);
        _database = client.GetDatabase(mongoSettings.DatabaseName);
    }

    public IMongoDatabase GetDatabase()
    {
        return _database;
    }
}