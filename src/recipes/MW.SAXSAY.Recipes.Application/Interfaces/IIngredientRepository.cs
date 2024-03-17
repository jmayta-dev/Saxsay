using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IIngredientRepository : IDisposable
{
    Task<IEnumerable<Ingredient>> GetIngredientsByRecipe(
        RecipeId id, CancellationToken cancellationToken);
}