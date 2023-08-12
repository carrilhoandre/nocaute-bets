using MongoDB.Driver;
using NocauteBets.Infra.MongoDb.Contexts;
using Shared.Domain;
using Shared.Repositories;

namespace NocauteBets.Infra.MongoDb.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : AggregateRoot
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected BaseRepository(IMongoDbContext context, string collectionName)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(collectionName);
        }

        public void AddAsync(TEntity obj, CancellationToken cancellationToken = default)
        {
            DbSet.InsertOneAsync(obj, cancellationToken: cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return (await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id), cancellationToken: cancellationToken))
                               .SingleOrDefault(cancellationToken);
        }

        public void UpdateAsync(TEntity obj, CancellationToken cancellationToken = default)
        {
            DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.Id), obj, cancellationToken: cancellationToken);
        }

        public void BulkWriteAsync(IEnumerable<TEntity> objs, CancellationToken cancellationToken = default)
        {
            try
            {
                var updates = new List<WriteModel<TEntity>>();
                foreach (var doc in objs)
                {
                    updates.Add(new ReplaceOneModel<TEntity>(Builders<TEntity>.Filter.Eq("_id", doc.Id), doc));
                }

                var result = DbSet.BulkWriteAsync(updates, new BulkWriteOptions() { IsOrdered = false }, cancellationToken).Result;
            }
            catch(Exception ex)
            {

            }
        }

        public void RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id), cancellationToken: cancellationToken);
        }

        public void Dispose() => Context?.Dispose();

        public IQueryable<TEntity> AsQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
