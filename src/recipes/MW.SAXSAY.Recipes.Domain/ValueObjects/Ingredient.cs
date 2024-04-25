using MW.SAXSAY.Recipes.Domain.Entities;

namespace MW.SAXSAY.Recipes.Domain.ValueObjects;

public class Ingredient
{
    public int RecipeId { get; set; }
    public int RawMaterialId { get; set; }
    public float Quantity { get; set; }
    public int UnitOfMeasureId { get; set; }
    public Recipe? Recipe { get; set; }
}