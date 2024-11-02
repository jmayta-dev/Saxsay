using MediatR;
using MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetAllRawMaterials;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Queries.GetRawMaterialsByFilter;

public record GetRawMaterialsByFilterQuery(string QueryString)
    : IRequest<Result<IEnumerable<GetRawMaterialDTO>>>;
