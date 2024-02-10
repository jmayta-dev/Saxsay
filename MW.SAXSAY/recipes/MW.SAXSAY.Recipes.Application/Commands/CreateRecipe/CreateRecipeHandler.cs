using System.Transactions;
using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

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
        if (PreparationTime.Create(command.Hours, command.Minutes) 
            is not PreparationTime preparationTime)
        {
            throw new ArgumentException(nameof(preparationTime));
        }

        RecipeDto recipeDto = new (
            null,
            command.Name,
            preparationTime,
            command.Portions,
            command.ImageUrl,
            command.Preparation,
            command.Calories,
            command.CommentsSuggestions
        );

        await _recipeRepository.CreateRecipe(recipeDto, cancellationToken);
        await _unitOfWork.SaveChanges(cancellationToken);
        return Unit.Value;
    }
    #endregion
}