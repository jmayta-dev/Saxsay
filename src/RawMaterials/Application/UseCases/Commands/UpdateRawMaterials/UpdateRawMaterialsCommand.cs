using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands.UpdateRawMaterials;

public record UpdateRawMaterialCommand(
    IEnumerable<UpdateRawMaterialDTO> RawMaterialsForUpdate) : IRequest<Result>;