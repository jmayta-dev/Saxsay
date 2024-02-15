using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.CreateRecipe;

public record CreateRecipeCommand(
    RecipeId? Id,
    string Name,
    uint Hours,
    uint Minutes,
    int Portions,
    string ImageUrl,
    string Preparation,
    double Calories,
    string CommentsSuggestions,
    IEnumerable<RawMaterial>? Ingredients
);