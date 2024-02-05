using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository
{
    ValueTask<RecipeDto> GetRecipeByIdAsync(
        RecipeId id, CancellationToken cancellationToken);
    ValueTask<IEnumerable<RecipeDto>> GetRecipeAll();
    ValueTask<RecipeId> CreateRecipe(RecipeDto recipeDTO);
}