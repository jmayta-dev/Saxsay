namespace MW.SAXSAY.RawMaterials.Domain.Interfaces;

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