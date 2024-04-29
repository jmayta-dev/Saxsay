
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.RawMaterials.Domain.ValueObjects;

namespace MW.SAXSAY.RawMaterials.Domain.Interfaces;

public interface IIngredientRepository
{
    Task<Ingredient> GetAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Ingredient>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<IngredientId?> RegisterAsync(
        Ingredient ingredient,
        CancellationToken cancellationToken = default);
    Task BulkRegisterAsync(
        IEnumerable<Ingredient> ingredientCollection,
        CancellationToken cancellationToken = default);
}