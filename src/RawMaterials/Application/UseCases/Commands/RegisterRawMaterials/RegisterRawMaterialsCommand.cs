using MediatR;
using MW.SAXSAY.RawMaterials.Application.DTO;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RegisterRawMaterials;

public record RegisterRawMaterialCommand(
    IEnumerable<RegisterRawMaterialDTO> RawMaterialsForRegister) : IRequest<Result>;