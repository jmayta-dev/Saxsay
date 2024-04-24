using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace MW.SAXSAY.Ingredients.Infrastructure.Persistence.SQLite.Context;

public class IngredientDbContext
{
    #region Properties & Variables
    //
    // private
    //
    private readonly string _connectionString;
    //
    // public
    //
    public IDbConnection Connection => new SqliteConnection(_connectionString);
    #endregion

    #region Constructor
    public IngredientDbContext(IConfiguration configuration)
    {
        // application base path
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // database relative path
        string relativePath = "db\\saxsay.ingredient.db";
        // combine paths
        string dbPath = Path.Combine(baseDirectory, relativePath);
        // build ConnectionString
        var csBuilder = new SqliteConnectionStringBuilder
        {
            DataSource = $"{dbPath}",
            Cache = SqliteCacheMode.Shared
        };

        _connectionString =
            configuration.GetConnectionString("SAXSAY.Ingredients.SQLite.DB") ??
            csBuilder.ConnectionString;
    }
    #endregion
}
