using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Application.Extensions;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.Interfaces;

namespace MW.SAXSAY.Recipes.Application.UseCases.Queries.GetAllQuery;

public class GetAllRecipesQueryHandler
    : IRequestHandler<GetAllRecipesQuery, BaseResponse<IEnumerable<RecipeDto>>>
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IUnitOfWorkRecipe _unitOfWorkRecipe;
    //
    // privates
    //

    //
    // publics
    //
    #endregion

    #region Costructor
    public GetAllRecipesQueryHandler(IUnitOfWorkRecipe unitOfWorkRecipe)
    {
        _unitOfWorkRecipe = unitOfWorkRecipe;
    }
    #endregion

    #region Mapping
    #endregion

    #region Methods
    public async Task<BaseResponse<IEnumerable<RecipeDto>>> Handle(
        GetAllRecipesQuery request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<RecipeDto>>();

        try
        {
            IEnumerable<Recipe> recipes =
                await _unitOfWorkRecipe.RecipeRepository.GetAllAsync(cancellationToken);

            response.Data = recipes.Select(recipe => recipe.ToRecipeDto()).ToList();
            response.Message = "Success!";
            response.IsSuccess = true;
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