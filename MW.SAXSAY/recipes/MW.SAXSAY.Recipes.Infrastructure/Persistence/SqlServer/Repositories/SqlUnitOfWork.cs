using System.Data;
using System.Transactions;
using Microsoft.Data.SqlClient;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes
    .MW.SAXSAY.Recipes.Infraestructure
    .Persistence
    .SqlServer
    .Repositories;

public class SqlUnitOfWork : IUnitOfWork
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly TransactionScope _scope;
    //
    // privates
    //
    private bool disposed = false;
    //
    // publics
    //

    #endregion

    #region Constructor
    public SqlUnitOfWork(TransactionScope scope)
    {
        scope = _scope;
    }
    #endregion

    #region Methods
    public Task SaveChangesAsync(CancellationToken cancellationToken, TransactionScope? scope = null)
    {
        scope?.Complete();
        return Task.CompletedTask;
    }
    #endregion

    #region IDisposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _scope?.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~SqlUnitOfWork()
    {
        Dispose(false);
    }
    #endregion
}