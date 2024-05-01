
using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Application.Extensions;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.Interfaces;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, BaseResponse<RecipeDto>>
{
    #region Dependencies
    //
    // dependency
    //
    private readonly IUnitOfWorkRecipe _unitOfWorkRecipe;
    #endregion

    #region Constructor
    public GetRecipeByIdQueryHandler(IUnitOfWorkRecipe unitOfWorkRecipe)
    {
        _unitOfWorkRecipe = unitOfWorkRecipe;
    }
    #endregion

    #region Methods
    public async Task<BaseResponse<RecipeDto>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        BaseResponse<RecipeDto> response = new();
        RecipeId recipeId = new() { Value = request.Id };

        try
        {
            Recipe recipe =
            await _unitOfWorkRecipe
                .RecipeRepository
                .GetByIdAsync(recipeId, cancellationToken);

            response.Data = recipe.ToRecipeDto();
            response.IsSuccess = true;
            response.Message = "Success!";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.IsSuccess = false;
            throw;
        }

        return response;
    }
    #endregion
}