using Microsoft.Data.SqlClient;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using System.Data;

namespace MW.SAXSAY.RawMaterials.Persistence.SQLServer.Repositories;

public class RawMaterialRepository : IRawMaterialRepository
{
    #region Properties & Variables
    private readonly SqlConnection _connection;
    private readonly SqlTransaction? _transaction;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="RawMaterialRepository"/> class.
    /// </summary>
    /// <param name="connection"></param>
    public RawMaterialRepository(SqlConnection connection)
    {
        // connection must be not-null and opened
        ArgumentNullException.ThrowIfNull(connection);
        if (connection.State == ConnectionState.Closed)
            throw new InvalidOperationException("Connection is closed");

        _connection = connection;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RawMaterialRepository"/> class.
    /// Usually used for updating or insertion purposes.
    /// </summary>
    /// <param name="connection">The <see cref="SqlConnection"/> instance to use.</param>
    /// <param name="transaction"></param>
    public RawMaterialRepository(SqlConnection connection, SqlTransaction transaction)
        : this(connection)
    {
        _transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion
}