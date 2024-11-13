using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

namespace MW.SAXSAY.RawMaterials.Application.Contracts;

public interface IRawMaterialRepository
{
    Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRawMaterialDTO>> GetByFilterAsync(string queryString, CancellationToken cancellationToken = default);
}