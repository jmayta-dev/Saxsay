using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.Queries.GetRecipeById;

public record GetRecipeByIdQuery(RecipeId Id) : IRequest<RecipeDTO>;