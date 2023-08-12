using DevKreator.Projects.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace NocauteBets.Infra.MongoDb.Contexts
{
    public class MongoDbContext : IMongoDbContext, IDisposable
    {
        private readonly MongoSettings _settings;
        private IMongoDatabase _database;
        
        public MongoClient MongoClient { get; set; }

        public IClientSessionHandle Session { get; set; }

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            _settings = settings.Value;
            MongoClient = new MongoClient(_settings.ConnectionString);
            if (MongoClient == null)
                return;
            _database = MongoClient.GetDatabase(_settings.Database, null);
            ConfigureMongo();
        }

        public IMongoCollection<T> GetCollectionByType<T>() => _database.GetCollection<T>(nameof(T), null);

        public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name, null);

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;
            MongoClient = new MongoClient(_settings.ConnectionString);
            if (MongoClient != null)
                _database = MongoClient.GetDatabase(_settings.Database, null);

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
