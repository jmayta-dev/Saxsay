using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace recipes.MW.SAXSAY.Recipes.Infrastructure.Persistence.SqlServer.Context;

public class ApplicationDbContext
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    #endregion

    #region Constructor
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("MwSaxsayConnection") ?? "";
    }
    #endregion

    #region Methods
    public IDbConnection Connection => new SqlConnection(_connectionString);
    #endregion

}