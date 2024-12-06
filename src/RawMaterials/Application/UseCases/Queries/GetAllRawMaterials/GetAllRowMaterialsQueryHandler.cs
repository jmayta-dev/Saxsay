using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

public class GetAllRowMaterialsQueryHandler
    : IRequestHandler<GetAllRawMaterialsQuery, Result<IEnumerable<GetRawMaterialDTO>>>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRawMaterial _unitOfWork;
    #endregion

    #region Constructor
    public GetAllRowMaterialsQueryHandler(IUnitOfWorkRawMaterial unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    #endregion

    #region Methods
    public async Task<Result<IEnumerable<GetRawMaterialDTO>>> Handle(
        GetAllRawMaterialsQuery request, CancellationToken cancellationToken)
    {
        var rawMaterials = await _unitOfWork
            .RawMaterialRepository
            .GetAllAsync(cancellationToken);

        if (rawMaterials == null)
            return Result<IEnumerable<GetRawMaterialDTO>>.Failure(new Error(
                "RawMaterials.NotFound",
                "No se pudo obtener la(s) materia(s) prima(s)."));

        return Result<IEnumerable<GetRawMaterialDTO>>.Success(rawMaterials);
    }
    #endregion
}
