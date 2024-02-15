using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository : IDisposable
{
    // Task<RecipeId> CreateRecipe(
    //     Recipe recipe,
    //     CancellationToken cancellationToken);
    // Task<bool> DeleteRecipe(
    //     RecipeDto recipeDto,
    //     CancellationToken cancellationToken);
    Task<IEnumerable<RecipeDto>> GetAllRecipes(
        CancellationToken cancellationToken);

    Task<RecipeDto> GetRecipeById(
        RecipeId id,
        CancellationToken cancellationToken);
    // Task<RecipeDto> UpdateRecipe(
    //     RecipeDto recipeDto,
    //     CancellationToken cancellationToken);
}