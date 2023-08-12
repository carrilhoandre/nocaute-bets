using Shared.Domain;

namespace Shared.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : AggregateRoot
    {
        public IQueryable<TEntity> AsQueryable();
        void AddAsync(TEntity obj, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void UpdateAsync(TEntity obj, CancellationToken cancellationToken = default);
        void RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        void BulkWriteAsync(IEnumerable<TEntity> objs, CancellationToken cancellationToken = default);
    }
}
