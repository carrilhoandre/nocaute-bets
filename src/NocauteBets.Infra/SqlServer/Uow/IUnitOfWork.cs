namespace NocauteBets.Infra.SqlServer.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
