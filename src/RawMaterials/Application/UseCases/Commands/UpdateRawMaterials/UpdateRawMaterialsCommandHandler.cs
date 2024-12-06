using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands.UpdateRawMaterials;

public class UpdateRawMaterialsCommandHandler
    : IRequestHandler<UpdateRawMaterialCommand, Result>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRawMaterial _unitOfWork;
    #endregion

    #region Constructor
    public UpdateRawMaterialsCommandHandler(IUnitOfWorkRawMaterial unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    #endregion

    #region Methods
    public async Task<Result> Handle(UpdateRawMaterialCommand command, CancellationToken cancellationToken)
    {
        // transform DTO to entity
        List<RawMaterial> rawMaterials = command.RawMaterialsForUpdate.Select(
            dto => RawMaterial.RawMaterialBuilder.Empty()
                .WithId(dto.Id)
                .WithName(dto.Name)
                .WithUNSPSC(dto.UNSPSC)
                .WithUNSPSCDescription(dto.UNSPSCDescription)
                .WithCreationDate(dto.CreatedAt)
                .WithUpdatingDate(dto.UpdatedAt)
                .WithEnableState(dto.IsEnabled)
                .Build()
        ).ToList();

        List<Task<bool>> taskList = [];
        // insert the raw materials
        foreach (RawMaterial rawMaterial in rawMaterials)
        {
            taskList.Add(_unitOfWork.RawMaterialRepository.UpdateRawMaterial(rawMaterial, cancellationToken));
        }

        // task execution massively
        var updatingResults = await Task.WhenAll(taskList);
        if (updatingResults.Any(r => r == false))
        {
            // rollback on error
            await _unitOfWork.RollbackAsync(cancellationToken);
            return Result.Failure(new Error("RawMaterials.UpdateFailed"));
        }

        // commit operations
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
    #endregion
}