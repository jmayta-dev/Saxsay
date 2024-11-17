using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.RawMaterials.Domain.Entities;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RegisterRawMaterials;

public class RegisterRawMaterialCommandHandler
    : IRequestHandler<RegisterRawMaterialCommand, Result>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRawMaterial _unitOfWork;
    #endregion

    #region Constructor
    public RegisterRawMaterialCommandHandler(IUnitOfWorkRawMaterial unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }
    #endregion

    #region Methods
    public async Task<Result> Handle(
        RegisterRawMaterialCommand command,
        CancellationToken cancellationToken = default)
    {
        // transform DTO to entity
        List<RawMaterial> rawMaterials = command.RawMaterialsForRegister.Select(
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
            taskList.Add(_unitOfWork
                .RawMaterialRepository
                .InsertRawMaterial(rawMaterial, cancellationToken)
            );
        }

        // mass task execution
        var insertionResults = await Task.WhenAll(taskList);
        if (insertionResults.Any(r => r == false))
        {   
            // rollback on error
            await _unitOfWork.RollbackAsync(cancellationToken);
            return Result.Failure(new Error("RawMaterials.InsertionFailed"));
        }

        // commit operations
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
    #endregion
}
