using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Application.Queries.GetRecipeAll;

public class GetRecipeAllHandler
    : IRequestHandler<GetRecipeAllQuery, IEnumerable<RecipeDto>>
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
    public GetRecipeAllHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    #endregion

    public async Task<IEnumerable<RecipeDto>> Handle(
        GetRecipeAllQuery request,
        CancellationToken cancellationToken)
    {
        var recipes = await _recipeRepository.GetRecipeAll(cancellationToken);
        return recipes;
    }
}