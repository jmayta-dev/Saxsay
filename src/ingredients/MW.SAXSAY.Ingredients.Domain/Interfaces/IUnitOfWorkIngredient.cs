
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Domain.Interfaces;

public interface IUnitOfWorkIngredient : IDisposable
{
    //
    // repositories
    //
    public IIngredientRepository IngredientRepository { get; }
    //
    // methods
    //
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}