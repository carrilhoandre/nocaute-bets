using Microsoft.EntityFrameworkCore;
using NocauteBets.Infra.SqlServer.Contexts;
using Shared.Domain;
using Shared.Repositories;

namespace NocauteBets.Infra.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : AggregateRoot
    {
        protected readonly NocauteBetsDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(NocauteBetsDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddRange(IEnumerable<TEntity> obj)
        {
            DbSet.AddRange(obj);
        }

        public void RemoveRange(IEnumerable<TEntity> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public bool Has(int id)
        {
            return DbSet.Find(id) != null;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return DbSet;
        }

        public void AddAsync(TEntity obj, CancellationToken cancellationToken = default)
        {
            DbSet.Add(obj);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public void UpdateAsync(TEntity obj, CancellationToken cancellationToken = default)
        {
            DbSet.Update(obj);
        }

        public void RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void BulkWriteAsync(IEnumerable<TEntity> objs, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
