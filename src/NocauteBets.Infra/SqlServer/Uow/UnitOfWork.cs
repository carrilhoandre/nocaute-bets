using NocauteBets.Infra.SqlServer.Contexts;

namespace NocauteBets.Infra.SqlServer.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NocauteBetsDbContext _context;

        public UnitOfWork(NocauteBetsDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
