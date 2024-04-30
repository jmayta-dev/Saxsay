using System.Data;
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.RawMaterials.Domain.Interfaces;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries;

public class GetAllIngredientsQueryHandler
    : IRequestHandler<GetAllRawMaterialsQuery, BaseResponse<IEnumerable<RawMaterialDto>>>
{
    private readonly IUnitOfWorkRawMaterial _unitOfWorkRawMaterial;

    public GetAllIngredientsQueryHandler(IUnitOfWorkRawMaterial unitOfWorkRawMaterial)
    {
        _unitOfWorkRawMaterial =
            unitOfWorkRawMaterial ??
            throw new ArgumentNullException(nameof(unitOfWorkRawMaterial));
    }

    public async Task<BaseResponse<IEnumerable<RawMaterialDto>>> Handle(
        GetAllRawMaterialsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<RawMaterialDto>>();
        try
        {
            var ingredients =
                await _unitOfWorkRawMaterial
                        .RawMaterialRepository
                        .GetAllAsync(cancellationToken);

            if (ingredients is not null)
            {
                // parse RawMaterial to RawMaterialDto
                List<RawMaterialDto> rawMaterialsDto =
                ingredients.Select(
                    r => new RawMaterialDto(r.Id!.Value, r.Description, r.IsActive, r.BaseUnitId)
                ).ToList();

                response.IsSuccess = true;
                response.Data = rawMaterialsDto;
                response.Message = "Success!";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            throw;
        }
        return response;
    }
}