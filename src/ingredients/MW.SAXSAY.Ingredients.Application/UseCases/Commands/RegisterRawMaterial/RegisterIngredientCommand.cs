using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Domain.ValueObjects;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands;

public record RegisterRawMaterialCommand(
    string Description,
    bool IsActive,
    int BaseUnitId
) : IRequest<BaseResponse<IngredientId>>;