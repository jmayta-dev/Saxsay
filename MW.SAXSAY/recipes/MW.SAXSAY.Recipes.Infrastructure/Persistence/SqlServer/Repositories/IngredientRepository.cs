using System.Data;
using Microsoft.Data.SqlClient;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Infrastructure.Extension;
using recipes.MW.SAXSAY.Recipes.Infrastructure.Persistence.SqlServer.Context;

namespace recipes.MW.SAXSAY.Recipes.Infraestructure.Persistence.SqlServer.Repositories;

public class IngredientRepository : IIngredientRepository
{
    #region Properties & Variables
    //
    // dependency
    //
    private readonly ApplicationDbContext _context;
    private readonly SqlConnection _connection;
    //
    // public
    //

    //
    // private
    //
    private bool disposed = false;

    #endregion

    #region Constructor
    public IngredientRepository(ApplicationDbContext context)
    {
        _context = context;
        _connection = (SqlConnection)context.Connection;
    }
    #endregion

    #region Methods
    private static Ingredient MapIngredient(IDataReader reader)
    {
        RawMaterialId rawMaterialId = new(reader.GetInt32("RawMaterialId"));
        RecipeId recipeId = new(reader.GetInt32("RecipeId"));
        return new Ingredient()
        {
            Id = new IngredientId(reader.GetInt32("IngredientId")),
            RawMaterialId = rawMaterialId,
            RawMaterialName = reader.GetStringOrNull("RawMaterialName"),
            RecipeId = recipeId,
            RecipeName = reader.GetStringOrNull("RecipeName"),
            Quantity = reader.GetDouble("Quantity")
        };
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByRecipe(
        RecipeId id, CancellationToken cancellationToken)
    {
        List<Ingredient> ingredientCollection = new();
        string sp = "recipe.uspGetRecipeIngredients";
        SqlParameter parameter = new()
        {
            ParameterName = "@RecipeId",
            SqlDbType = SqlDbType.Int,
            Value = id.Value
        };
        using SqlCommand command = new(sp, _connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(parameter);
        _connection.Open();
        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        if (reader.HasRows)
            while (await reader.ReadAsync(cancellationToken))
                ingredientCollection.Add(MapIngredient(reader));
        return ingredientCollection;
    }
    #endregion

    #region Support IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();
            }
            disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion



}