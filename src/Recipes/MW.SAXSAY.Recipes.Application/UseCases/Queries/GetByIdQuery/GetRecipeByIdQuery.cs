using MediatR;
using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Application.DTOs;

namespace MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

public record GetRecipeByIdQuery(int Id) : IRequest<BaseResponse<RecipeDto>>;