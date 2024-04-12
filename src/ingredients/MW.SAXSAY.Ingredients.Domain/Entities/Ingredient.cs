using MW.CHUYA.Domain.Common.Interfaces;

namespace MW.SAXSAY.Ingredients.Domain.Entities;

public class Ingredient : IEntity<IngredientId>
{
    public IngredientId? Id { get; set; }
    public RawMaterialId RawMaterialId { get; set; }
    public string? RawMaterialName { get; set; }
    public RecipeId RecipeId { get; set; }
    public string? RecipeName { get; set; }
    public double Quantity { get; set; }

    public Ingredient(IngredientId? id, RawMaterialId rawMaterialId, RecipeId recipeId)
        : this(rawMaterialId, recipeId)
    {
        Id = id;
    }

    public Ingredient(RawMaterialId rawMaterialId, RecipeId recipeId)
    {
        RawMaterialId = rawMaterialId;
        RecipeId = recipeId;
    }

    public Ingredient() { }
}