using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

namespace MW.SAXSAY.RawMaterials.Application.Contracts;

public interface IRawMaterialRepository
{
    Task<IEnumerable<GetRawMaterialDTO>> GetAllAsync(
        CancellationToken cancellationToken = default);
}