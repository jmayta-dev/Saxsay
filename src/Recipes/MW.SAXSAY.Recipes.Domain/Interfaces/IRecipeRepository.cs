using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository
{
    Task<Recipe> GetByIdAsync(
        RecipeId recipeId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<RecipeId?> RegisterAsync(
        Recipe recipe,
        CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(
        Recipe recipe,
        CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(
        RecipeId recipeId,
        CancellationToken cancellationToken = default);
}