using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository: IDisposable
{
    Task<IEnumerable<RecipeDto>> GetRecipeAll(
        CancellationToken cancellationToken);
    Task<RecipeId> CreateRecipe(
        RecipeDto recipeDTO,
        CancellationToken cancellationToken);
    Task<RecipeId> DeleteRecipe(
        RecipeDto recipeDto,
        CancellationToken cancellationToken);
    Task<RecipeDto> GetRecipeById(
        RecipeId id,
        CancellationToken cancellationToken);
    Task<RecipeDto> UpdateRecipe(
        RecipeDto recipeDto,
        CancellationToken cancellationToken);
}