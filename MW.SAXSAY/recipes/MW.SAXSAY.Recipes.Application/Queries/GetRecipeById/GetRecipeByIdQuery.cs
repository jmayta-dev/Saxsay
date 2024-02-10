using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;

namespace recipes.MW.SAXSAY.Recipes.Application.Queries.GetRecipeById;

public record GetRecipeByIdQuery(int Id) : IRequest<RecipeDto>;