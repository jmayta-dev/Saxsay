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
    public Guid GuidConnection => Guid.NewGuid();
    #endregion

    #region Constructor
    public IngredientDbContext(IConfiguration configuration)
    {
        _connectionString =
            configuration
                .GetConnectionString(
                    "SAXSAY.Ingredients.SQLite.DB") ?? string.Empty;
    }
    #endregion
}