using MongoDB.Driver;

namespace NocauteBets.Infra.MongoDb.Contexts
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<T> GetCollection<T>(string name);

        IMongoCollection<T> GetCollectionByType<T>();
    }
}
