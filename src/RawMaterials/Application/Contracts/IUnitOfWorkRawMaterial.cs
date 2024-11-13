namespace MW.SAXSAY.RawMaterials.Application.Contracts;

public interface IUnitOfWorkRawMaterial : IDisposable
{
    //
    // repositories
    //
    IRawMaterialRepository RawMaterialRepository { get; }

    //
    // methods
    //
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}