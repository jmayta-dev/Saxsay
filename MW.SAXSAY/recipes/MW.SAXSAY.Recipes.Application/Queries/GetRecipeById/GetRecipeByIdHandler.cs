
using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Application.Queries.GetRecipeById;

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
        var recipeDTO =
            await _recipeRepository.GetRecipeByIdAsync(
                new RecipeId(query.Id), cancellationToken);

        if (recipeDTO?.Id is null)
        {
            throw new ArgumentException(nameof(recipeDTO));
        }

        return new RecipeDto(
            recipeDTO.Id,
            recipeDTO.PreparationTime,
            recipeDTO.Portions,
            recipeDTO.ImageUrl,
            recipeDTO.Preparation,
            recipeDTO.Calories,
            recipeDTO.CommentsSuggestions
        );
    }
    #endregion
}