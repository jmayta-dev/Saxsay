using Microsoft.Data.SqlClient;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;
using recipes.MW.SAXSAY.Recipes.Infrastructure.Extension;
using recipes.MW.SAXSAY.Recipes.Infrastructure.Persistence.SqlServer.Context;
using System.Data;

namespace recipes.MW.SAXSAY.Recipes.Infraestructure.Persistence.SqlServer.Repositories;

public class RecipeRepository : IRecipeRepository
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly ApplicationDbContext _context;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly SqlConnection _connection;
    //
    // privates
    //
    private bool disposed = false;
    //
    // publics
    //

    #endregion

    #region Constructor
    public RecipeRepository(
        ApplicationDbContext context,
        IIngredientRepository ingredientRepository)
    {
        _context = context;
        _connection = (SqlConnection)_context.Connection;
        _ingredientRepository = ingredientRepository;
    }
    #endregion

    #region Methods
    private static RecipeDto MapRecipeDto(IDataReader reader)
    {
        RecipeId id = new(reader.GetInt32("RecipeId"));
        PreparationTime? preparationTime =
            PreparationTime.Create(reader.GetString("PreparationTime"));
        return new RecipeDto(
            id: id,
            name: reader.GetString("Name"),
            preparationTime: preparationTime ?? new PreparationTime(),
            portions: reader.GetInt32("Portions"),
            imageUrl: reader.GetString("ImageUrl"),
            preparation: reader.GetString("Preparation"),
            calories: reader.GetDouble("Calories"),
            commentsSuggestions: reader.GetString("CommentSuggestion"),
            ingredients: null
        );
    }

    public async Task<IEnumerable<RecipeDto>> GetAllRecipes(
        CancellationToken cancellationToken)
    {
        RecipeDto recipeDTO = new();
        List<RecipeDto> recipeList = new();
        using SqlCommand command = new("recipe.uspGetAllRecipes", _connection);
        command.CommandType = CommandType.StoredProcedure;
        _connection.Open();
        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        if (reader.HasRows)
        {
            while (await reader.ReadAsync(cancellationToken))
            {
                recipeDTO = MapRecipeDto(reader);
                if (recipeDTO?.Id != null)
                {
                    IEnumerable<Ingredient> ingredients =
                        await _ingredientRepository
                            .GetIngredientsByRecipe(recipeDTO.Id, cancellationToken);
                    recipeList.Add(MapRecipeDto(reader) with { Ingredients = ingredients });
                }
                else
                {
                    recipeList.Add(MapRecipeDto(reader));
                }
            }
        }
        return recipeList;
    }

    public async Task<RecipeDto> GetRecipeById(RecipeId id, CancellationToken cancellationToken)
    {
        RecipeDto recipeDTO = new();
        using SqlCommand command = new("recipe.uspGetRecipeById", _connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter
        {
            ParameterName = "@RecipeId",
            SqlDbType = SqlDbType.Int,
            Value = id.Value
        });
        _connection.Open();
        using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
        if (reader.HasRows)
            while (await reader.ReadAsync(cancellationToken))
            {
                recipeDTO = MapRecipeDto(reader);
                IEnumerable<Ingredient> ingredients =
                    await _ingredientRepository.GetIngredientsByRecipe(id, cancellationToken);
                recipeDTO = recipeDTO with { Ingredients = ingredients };
            }
        return recipeDTO;
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