using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;

namespace MW.SAXSAY.Recipes.Application.UseCases.Queries.GetAllQuery;

public record GetAllRecipesQuery() : IRequest<BaseResponse<IEnumerable<RecipeDto>>>;