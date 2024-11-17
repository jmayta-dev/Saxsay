using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Domain.Entities;

namespace MW.SAXSAY.RawMaterials.Application.Contracts;

public interface IRawMaterialRepository
{
    Task<bool> DeleteRawMaterial(string rawMaterialId, CancellationToken cancellationToken = default);
    Task<bool> InsertRawMaterial(RawMaterial rawMaterial, CancellationToken cancellationToken = default);
    Task<bool> UpdateRawMaterial(RawMaterial rawMaterial, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRawMaterialDTO>> GetByFilterAsync(string queryString, CancellationToken cancellationToken = default);
}