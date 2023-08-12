namespace NocauteBets.Infra.MongoDb.Contexts
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IMongoDbContext _context;

        public UnitOfWork(IMongoDbContext context) => _context = context;

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default) => true; 

        public void Dispose() => _context.Dispose();
    }
}
