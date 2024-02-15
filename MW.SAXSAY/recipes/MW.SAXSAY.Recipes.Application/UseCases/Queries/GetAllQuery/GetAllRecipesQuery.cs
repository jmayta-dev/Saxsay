using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetAllQuery;

public record GetAllRecipesQuery() : IRequest<IEnumerable<RecipeDto>>;