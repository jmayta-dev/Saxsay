using Microsoft.Data.SqlClient;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Persistence.SQLServer.Context;

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
    }
    #endregion

    #region Disposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}