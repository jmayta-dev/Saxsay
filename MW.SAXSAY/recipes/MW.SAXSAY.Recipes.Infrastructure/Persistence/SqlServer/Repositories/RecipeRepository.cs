using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes
    .MW.SAXSAY.Recipes.Infraestructure
    .Persistence
    .SqlServer
    .Repositories;

public class RecipeRepository : IRecipeRepository
{
    #region Properties & Variables
    //
    // dependencies
    //

    //
    // privates
    //
    private bool disposed = false;
    //
    // publics
    //

    #endregion

    #region Constructor
    public RecipeRepository() { }
    #endregion

    #region Methods
    public async Task<RecipeId> CreateRecipe(
        RecipeDto recipeDTO,
        CancellationToken cancellationToken)
    {
        SqlParameter parameter = new ()
        {
            ParameterName = "@pRecipeId",
            SqlDbType = SqlDbType.Int,
            Value = DBNull.Value,
            Direction = ParameterDirection.Output
        };
        using SqlConnection connection = new("");
        await connection.OpenAsync(cancellationToken);
        using SqlCommand command = new("recipe.uspCreateRecipe", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(parameter);
        await command.ExecuteNonQueryAsync();
        var id = command.Parameters["@Parametro"].Value as int?;

        if (id is not null)
            return new RecipeId((int)id);
        return new RecipeId(0);
    }

    public Task<RecipeId> DeleteRecipe(
        RecipeDto recipeDto,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RecipeDto>> GetRecipeAll(
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RecipeDto> GetRecipeById(
        RecipeId id,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RecipeDto> UpdateRecipe(
        RecipeDto recipeDto,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Support IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                
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