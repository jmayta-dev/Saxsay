using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Application.Extensions;

public static class RecipeExtensions
{
    public static RecipeDto ToRecipeDto(this Recipe recipe)
    {
        List<IngredientDto> ingredients = new();
        if (recipe.Ingredients is not null && recipe.Ingredients.Any())
        {
            ingredients = recipe.Ingredients.Select(i => ToIngredientDto(i)).ToList();
        }

        return new RecipeDto
        {
            Id = recipe.Id?.Value,
            Name = recipe.Name,
            Ingredients = ingredients
        };
    }

    public static IngredientDto ToIngredientDto(this Ingredient ingredient)
    {
        return new IngredientDto
        {
            RawMaterialId = ingredient.RawMaterialId,
            Quantity = ingredient.Quantity,
            UnitOfMeasureId = ingredient.UnitOfMeasureId
        };
    }
}