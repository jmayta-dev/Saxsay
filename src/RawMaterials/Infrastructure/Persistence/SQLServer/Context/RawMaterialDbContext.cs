using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MW.SAXSAY.RawMaterials.Persistence.SQLServer.Context;

public sealed class RawMaterialDbContext
{
    #region Properties & Variables
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    #endregion

    #region Constructor
    public RawMaterialDbContext(IConfiguration configuration)
    {
        _configuration = configuration ??
            throw new ArgumentNullException(nameof(configuration));

        _connectionString = _configuration.GetConnectionString("mw-saxsay-db") ??
            throw new InvalidOperationException("Connection string has not been set.");
    }
    #endregion

    #region Methods
    public SqlConnection CreateConnection => new(_connectionString);
    #endregion
}