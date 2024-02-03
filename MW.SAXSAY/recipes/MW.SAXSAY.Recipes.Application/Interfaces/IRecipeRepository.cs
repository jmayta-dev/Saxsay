using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository
{
    ValueTask<RecipeDTO> GetRecipeByIdAsync(
        RecipeId id, CancellationToken cancellationToken);
    ValueTask<IEnumerable<RecipeDTO>> GetRecipeAll();
    ValueTask<RecipeId> CreateRecipe(RecipeDTO recipeDTO);
}