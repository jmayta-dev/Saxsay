using MediatR;
using recipes.MW.SAXSAY.Recipes.Application.DTOs;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Application.Commands.CreateRecipe;

public record CreateRecipeCommand(
    int Id,
    int Hours,
    int Minutes,
    int Portions,
    string ImageUrl,
    string Preparation,
    double Calories,
    string CommentsSuggestions,
    IEnumerable<DietaryRestriction>? DietaryRestriction,
    IEnumerable<RawMaterial>? RawMaterials,
    IEnumerable<NutritionalComponent>? NutritionalComponents
) : IRequest<Unit>;