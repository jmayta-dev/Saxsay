using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.Interfaces;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

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
    private IngredientDto ToIngredientDto(Ingredient ingredient)
    {
        return new IngredientDto {
            RawMaterialId = ingredient.RawMaterialId,
            Quantity = ingredient.Quantity,
            UnitOfMeasureId = ingredient.UnitOfMeasureId
        };
    }

    private RecipeDto ToRecipeDto(Recipe recipe)
    {
        List<IngredientDto> ingredients = new();
        if (recipe.Ingredients is not null && recipe.Ingredients.Any())
        {
            ingredients = recipe.Ingredients.Select(i => ToIngredientDto(i)).ToList();
        }

        return new RecipeDto
        {
            Id = recipe.Id?.Value,
            Name = recipe.Name,
            Ingredients = ingredients
        };
    }
    #endregion

    #region Methods
    public async Task<BaseResponse<IEnumerable<RecipeDto>>> Handle(
        GetAllRecipesQuery request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<RecipeDto>>();

        try
        {
            var recipeList =
                await _unitOfWorkRecipe.RecipeRepository.GetAllAsync(cancellationToken);

            response.Data = recipeList.Select(r => ToRecipeDto(r)).ToList();
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