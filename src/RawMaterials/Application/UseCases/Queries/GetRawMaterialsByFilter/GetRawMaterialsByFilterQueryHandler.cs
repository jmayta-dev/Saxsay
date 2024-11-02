using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetRawMaterialsByFilter;

public class GetRawMaterialsByFilterQueryHandler
        : IRequestHandler<
            GetRawMaterialsByFilterQuery,
            Result<IEnumerable<GetRawMaterialDTO>>>
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IUnitOfWorkRawMaterial _unitOfWork;
    #endregion

    #region Constructor
    public GetRawMaterialsByFilterQueryHandler(IUnitOfWorkRawMaterial unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    #endregion

    #region Methods
    public async Task<Result<IEnumerable<GetRawMaterialDTO>>> Handle(
        GetRawMaterialsByFilterQuery request, CancellationToken cancellationToken)
    {
        var rawMaterials = await _unitOfWork
            .RawMaterialRepository
            .GetByFilterAsync(request.QueryString, cancellationToken);

        if (rawMaterials == null)
            return Result<IEnumerable<GetRawMaterialDTO>>
                .Failure(new Error(
                    "RawMaterials.NotFound",
                    "No se pudo obtener la(s) materia(s) prima(s)."));

        return Result<IEnumerable<GetRawMaterialDTO>>.Success(rawMaterials);
    }

    #endregion
}