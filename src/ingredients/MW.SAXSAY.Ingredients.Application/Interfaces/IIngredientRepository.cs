using MW.SAXSAY.Ingredients.Domain.Entities;

namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IIngredientRepository : IDisposable
{
    Task<IEnumerable<Ingredient>> GetIngredientsByRecipe(
        RecipeId id, CancellationToken cancellationToken);
}