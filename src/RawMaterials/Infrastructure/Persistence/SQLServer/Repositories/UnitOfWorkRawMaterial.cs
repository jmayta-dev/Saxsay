using Microsoft.Data.SqlClient;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Context;
using System.Data;

namespace MW.SAXSAY.RawMaterials.Persistence.SQLServer.Repositories;

public class UnitOfWorkRawMaterial : IUnitOfWorkRawMaterial
{
    #region Properties & Variables
    //
    // private
    //
    private bool _disposed = false;
    private IRawMaterialRepository? _rawMaterialRepository;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    //
    // public
    //
    public IRawMaterialRepository RawMaterialRepository
    {
        get => _rawMaterialRepository ??=
            new RawMaterialRepository(_connection, _transaction);
    }
    #endregion

    #region Constructor
    public UnitOfWorkRawMaterial(RawMaterialDbContext context)
    {
        _connection = context.CreateConnection;
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }
    #endregion

    #region Methods
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction ??= (SqlTransaction)await _connection
                .BeginTransactionAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.CommitAsync(cancellationToken);
    }
    #endregion

    #region Disposable Support
    protected virtual async Task DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // handle transaction
                if (_transaction != null)
                { await _transaction.DisposeAsync(); }

                // handle connection
                if (_connection.State == ConnectionState.Open)
                { _connection.Close(); }
                await _connection.DisposeAsync();

            }
            _disposed = true;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // handle transaction
                _transaction?.Dispose();

                // handle connection
                if (_connection.State == ConnectionState.Open)
                { _connection.Close(); }
                _connection.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~UnitOfWorkRawMaterial()
    {
        Dispose(false);
    }
    #endregion
}