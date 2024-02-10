using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;

namespace recipes.MW.SAXSAY.Recipes.Application.Queries.GetRecipeAll;

public record GetRecipeAllQuery(): IRequest<IEnumerable<RecipeDto>>;