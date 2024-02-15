
using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
{
    #region Dependencies
    private readonly IRecipeRepository _recipeRepository;
    #endregion

    #region Constructor
    public GetRecipeByIdHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    #endregion

    #region Methods
    public async Task<RecipeDto> Handle(GetRecipeByIdQuery query, CancellationToken cancellationToken)
    {
        var recipeId = new RecipeId(query.Id);
        return await _recipeRepository.GetRecipeById(recipeId, cancellationToken);
    }
    #endregion
}