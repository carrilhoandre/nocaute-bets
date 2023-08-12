﻿namespace NocauteBets.Infra.MongoDb.Contexts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}
