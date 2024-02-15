using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.UpdateRecipe;

public record UpdateRecipeCommand(
    int Id,
    string Name,
    int Hours,
    int Minutes,
    int Portions,
    string ImageUrl,
    string Preparation,
    double Calories,
    string CommentsSuggestions,
    IEnumerable<DietaryRestriction>? DietaryRestriction,
    IEnumerable<Ingredient>? RawMaterials,
    IEnumerable<NutritionalComponent>? NutritionalComponents
);