
using MediatR;
using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.Interfaces;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

// public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
// {
//     #region Dependencies
//     private readonly IRecipeRepository _recipeRepository;
//     #endregion

//     #region Constructor
//     public GetRecipeByIdHandler(IRecipeRepository recipeRepository)
//     {
//         _recipeRepository = recipeRepository;
//     }
//     #endregion

//     #region Methods
//     public async Task<RecipeDto> Handle(GetRecipeByIdQuery query, CancellationToken cancellationToken)
//     {
//         return new RecipeId(query.Id);
//     }
//     #endregion
// }