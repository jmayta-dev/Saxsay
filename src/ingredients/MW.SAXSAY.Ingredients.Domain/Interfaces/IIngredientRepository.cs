
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Domain.Interfaces;

public interface IIngredientRepository
{
    Task<Ingredient> GetAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Ingredient>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IngredientId?> RegisterAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    Task BulkRegisterAsync(IEnumerable<Ingredient> ingredientCollection, CancellationToken cancellationToken = default);
}