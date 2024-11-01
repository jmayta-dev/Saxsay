namespace MW.SAXSAY.RawMaterials.Application.Contracts;

public interface IUnitOfWorkRawMaterial : IDisposable
{
    //
    // repositories
    //
    IRawMaterialRepository RawMaterialRepository { get; }
}