namespace MW.SAXSAY.RawMaterials.Domain.Interfaces;

public interface IUnitOfWorkRawMaterial : IDisposable
{
    //
    // repositories
    //
    public IRawMaterialRepository RawMaterialRepository { get; }
    //
    // methods
    //
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}