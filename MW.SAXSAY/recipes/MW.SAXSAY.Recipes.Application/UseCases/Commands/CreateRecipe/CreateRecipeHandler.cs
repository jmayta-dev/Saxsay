using System.Transactions;
using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.CreateRecipe;

public sealed class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, RecipeDto?>
{
    #region Dependecies
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Constructor
    public CreateRecipeCommandHandler(
        IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository =
            recipeRepository ??
            throw new ArgumentException($"{nameof(recipeRepository)} can't be null.");

        _unitOfWork =
            unitOfWork ??
            throw new ArgumentException($"{nameof(unitOfWork)} can't be null.");
    }
    #endregion

    #region Methods
    public async Task<RecipeDto?> Handle(
        CreateRecipeCommand command, CancellationToken cancellationToken)
    {
        try
        {
            if (PreparationTime.Create(command.Hours, command.Minutes)
                is not PreparationTime preparationTime)
            {
                throw new ArgumentException(nameof(preparationTime));
            }

            Recipe recipe = new
            (
                null,
                command.Name,
                preparationTime,
                command.Portions,
                command.ImageUrl,
                command.Preparation,
                command.Calories,
                command.CommentsSuggestions,
                command.Ingredients
            );

            using TransactionScope scope = new();
            RecipeId? recipeId =
                await _recipeRepository.CreateRecipe(recipe, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken, scope);

            if (recipeId == null)
            {
                return null;
            }

            RecipeDto recipeDto = new(
                recipeId,
                command.Name,
                preparationTime,
                command.Portions,
                command.ImageUrl,
                command.Preparation,
                command.Calories,
                command.CommentsSuggestions,
                command.Ingredients
            );
            return recipeDto;
        }
        catch (TransactionAbortedException)
        {
            throw;
        }
    }
    #endregion
}