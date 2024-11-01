using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Application.DTOs;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

public class GetAllRowMaterialsQueryHandler
    : IRequestHandler<GetAllRawMaterialsQuery, Result<IEnumerable<GetRawMaterialDTO>>>
{
    #region Properties & Variables
    #endregion

    #region Constructor
    public GetAllRowMaterialsQueryHandler() { }
    #endregion

    #region Methods
    public Task<Result<IEnumerable<GetRawMaterialDTO>>> Handle(
        GetAllRawMaterialsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    #endregion
}
