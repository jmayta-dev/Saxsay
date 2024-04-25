using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository : IDisposable
{
    Task<Recipe> GetAsync(
        RecipeId recipeId,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<RecipeId?> CreateAsync(
        Recipe recipe,
        CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(
        Recipe recipe,
        CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(
        CancellationToken cancellationToken = default);
}