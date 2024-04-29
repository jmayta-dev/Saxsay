
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Application.DTO;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries;

public record GetAllIngredientsQuery()
    : IRequest<BaseResponse<IEnumerable<RawMaterialDto>>>;