using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace recipes.MW.SAXSAY.Recipes.Infrastructure.Persistence;

public class DatabaseContext<T> where T : DbConnection, ICloneable, new()
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    #endregion

    #region Constructor
    public DatabaseContext(
        IConfiguration configuration, string connectionStringName)
    {
        _configuration = configuration;
        _connectionString =
            _configuration.GetConnectionString(connectionStringName) ?? "";
    }
    #endregion

    #region Methods
    public T GetConnection()
    {
        T connection = new T();
        connection.ConnectionString = _connectionString;
        return connection;
    }
    #endregion

}