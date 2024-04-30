
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.RawMaterials.Domain.ValueObjects;

namespace MW.SAXSAY.RawMaterials.Domain.Interfaces;

public interface IRawMaterialRepository
{
    Task<RawMaterial> GetAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<RawMaterial>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<RawMaterialId?> RegisterAsync(
        RawMaterial ingredient,
        CancellationToken cancellationToken = default);
    Task BulkRegisterAsync(
        IEnumerable<RawMaterial> ingredientCollection,
        CancellationToken cancellationToken = default);
}