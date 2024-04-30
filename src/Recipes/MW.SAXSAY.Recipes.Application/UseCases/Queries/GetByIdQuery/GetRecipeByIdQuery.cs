using MediatR;
using MW.SAXSAY.Recipes.Application.DTOs;

namespace recipes.MW.SAXSAY.Recipes.Application.UseCases.Queries.GetByIdQuery;

public record GetRecipeByIdQuery(int Id) : IRequest<RecipeDto>;