
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.Interfaces;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Application.UseCases.Commands.RegisterRecipe;

public class RegisterRecipeCommandHandler : IRequestHandler<RegisterRecipeCommand, BaseResponse<RecipeId>>
{
    #region Properties & Variables
    private readonly IUnitOfWorkRecipe _unitOfWorkRecipe;
    #endregion

    #region Constructor
    public RegisterRecipeCommandHandler(IUnitOfWorkRecipe unitOfWorkRecipe)
    {
        _unitOfWorkRecipe =
            unitOfWorkRecipe ??
            throw new ArgumentNullException(nameof(unitOfWorkRecipe));
    }
    #endregion

    #region Methods
    public async Task<BaseResponse<RecipeId>> Handle(
        RegisterRecipeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<RecipeId>();

        // prepare recipe domain model
        Recipe.RecipeBuilder recipeBuilder = new();
        recipeBuilder.WithName(request.Name!);
        recipeBuilder.WithPortions((int)request.Portions!);
        Recipe recipe = recipeBuilder.Build();

        try
        {
            // register recipe and get new id
            RecipeId? recipeId =
                await _unitOfWorkRecipe
                        .RecipeRepository
                        .RegisterAsync(recipe, cancellationToken);

            if (recipeId is null || recipeId.Value <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Failed to register recipe.";
                return response;
            }
            // register recipe ingredients
            if (request.Ingredients is not null)
            {
                foreach (var ingredient in request.Ingredients)
                {
                    var newIngredient = new Ingredient
                    {
                        RecipeId = recipeId.Value,
                        RawMaterialId = ingredient.RawMaterialId,
                        Quantity = ingredient.Quantity,
                        UnitOfMeasureId = ingredient.UnitOfMeasureId
                    };
                    recipe.AddIngredient(newIngredient);

                    // register the new ingredient
                    if (!await _unitOfWorkRecipe.IngredientRepository.RegisterAsync(newIngredient, cancellationToken))
                    {
                        response.IsSuccess = false;
                        response.Message = "Failed to register ingredient.";
                        return response;
                    }
                }
            }
            await _unitOfWorkRecipe.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
            var error = new BaseError
            {
                ErrorMessage = ex.Message,
                PropertyName = ex.Source
            };
            response.Errors = new List<BaseError> { error };
            await _unitOfWorkRecipe.RollbackAsync(cancellationToken);
            throw;
        }

        return response;
    }
    #endregion
}