using Microsoft.Data.Sqlite;
using MW.SAXSAY.RawMaterials.Domain.Interfaces;
using MW.SAXSAY.RawMaterials.Infrastructure.Persistence.SQLite.Context;

namespace MW.SAXSAY.RawMaterials.Infrastructure.Persistence.SQLite.Resitories;

public class UnitOfWorkIngredient : IUnitOfWorkIngredient
{
    #region Properties & Variables
    //
    // private
    //
    private bool _disposed = false;
    private readonly SqliteConnection _connection;
    private readonly SqliteTransaction _transaction;
    //
    // public
    //    
    public IIngredientRepository IngredientRepository =>
        new IngredientRepository(_connection, _transaction);
    #endregion // Properties & Variables

    #region Constructor
    public UnitOfWorkIngredient(IngredientDbContext context)
    {
        _connection = (SqliteConnection)context.Connection;
        _connection.Open();

        _transaction = _connection.BeginTransaction();
    }
    #endregion // Constructor

    #region IDisposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();

                _transaction?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion // IDisposable Support

    #region Methods
    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _transaction.Rollback(), cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _transaction.Commit(), cancellationToken);
    }
    #endregion // Methods

}