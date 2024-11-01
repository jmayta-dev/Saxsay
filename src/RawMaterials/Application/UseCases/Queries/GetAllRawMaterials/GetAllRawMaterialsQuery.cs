using MediatR;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;

public record GetAllRawMaterialsQuery()
    : IRequest<Result<IEnumerable<GetRawMaterialDTO>>>;