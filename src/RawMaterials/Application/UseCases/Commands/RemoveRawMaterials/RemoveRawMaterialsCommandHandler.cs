using MediatR;
using MW.SAXSAY.RawMaterials.Application.Contracts;
using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterials.Application.UseCases.Commands.RemoveRawMaterials;

public class RemoveRawMaterialsCommandHandler
    : IRequestHandler<RemoveRawMaterialsCommand, Result>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRawMaterial _unitOfWork;
    #endregion

    #region Constructor
    public RemoveRawMaterialsCommandHandler(IUnitOfWorkRawMaterial unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    #endregion

    #region Methods
    public async Task<Result> Handle(
        RemoveRawMaterialsCommand command, CancellationToken cancellationToken)
    {
        List<Task<bool>> taskList = [];
        foreach (var rawMaterial in command.RawMaterialsForDelete)
        {
            taskList.Add(_unitOfWork.RawMaterialRepository.DeleteRawMaterial(rawMaterial.Id, cancellationToken));
        }
        var deletionResults = await Task.WhenAll(taskList);
        if (deletionResults.Any(r => r == false))
        {
            // rollback on error
            await _unitOfWork.RollbackAsync(cancellationToken);
            return Result.Failure(new Error("RawMaterials.DeletionFailed"));
        }
        // commit operations
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();

    }
    #endregion
}