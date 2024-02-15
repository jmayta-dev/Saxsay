using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetAllQuery;

public class GetAllRecipesHandler
    : IRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeDto>>
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IRecipeRepository _recipeRepository;
    //
    // privates
    //

    //
    // publics
    //
    #endregion

    #region Costructor
    public GetAllRecipesHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    #endregion

    public async Task<IEnumerable<RecipeDto>> Handle(
        GetAllRecipesQuery request,
        CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetAllRecipes(cancellationToken);
        return recipes ?? new List<RecipeDto>();
    }
}