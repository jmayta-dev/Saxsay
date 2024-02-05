using MediatR;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.CreateRecipe;

public sealed class CreateRecipeCommandHandler
    : IRequestHandler<CreateRecipeCommand, Unit>
{
    #region Dependecies
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Constructor
    public CreateRecipeCommandHandler(
        IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository ?? throw new ArgumentException($"{nameof(recipeRepository)} can't be null.");
        _unitOfWork = unitOfWork ?? throw new ArgumentException($"{nameof(unitOfWork)} can't be null.");
    }
    #endregion

    #region Methods
    public async Task<Unit> Handle(
        CreateRecipeCommand command, CancellationToken cancellationToken)
    {
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    #endregion
}