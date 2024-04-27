
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IIngredientRepository
{
    Task<bool> RegisterAsync(Ingredient ingredient, CancellationToken cancellationToken);
    Task<bool> BulkRegisterAsync(IEnumerable<Ingredient> ingredientCollection, CancellationToken cancellationToken);
}