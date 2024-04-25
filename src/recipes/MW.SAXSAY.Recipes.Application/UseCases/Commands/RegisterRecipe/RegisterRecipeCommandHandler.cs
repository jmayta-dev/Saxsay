
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
        _unitOfWorkRecipe = unitOfWorkRecipe;
    }
    #endregion

    #region Methods
    public Task<BaseResponse<RecipeId>> Handle(
        RegisterRecipeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<RecipeId>();

        Recipe.RecipeBuilder recipeBuilder = new();
        recipeBuilder.WithName(request.Name);
        recipeBuilder.WithPortions((int)request.Portions);



        try
        {
            
        }
        catch (Exception)
        {
            
            throw;
        }
        throw new NotImplementedException();
    }
    #endregion
}