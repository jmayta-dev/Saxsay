using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public sealed class Recipe : IEntity<RecipeId>
{
    #region Properties
    public RecipeId? Id { get; set; }
    public string Name { get; set; }
    public PreparationTime PreparationTime { get; set; }
    public int Portions { get; set; }
    public string ImageUrl { get; set; }
    public string Preparation { get; set; }
    public double Calories { get; set; }
    public string CommentsSuggestions { get; set; }

    public IEnumerable<RawMaterial>? Ingredients { get; set; }
    #endregion

    #region Constructor
    public Recipe(
        RecipeId? id,
        string name,
        PreparationTime preparationTime,
        int portions,
        string imageUrl,
        string preparation,
        double calories,
        string commentsSuggestions,
        IEnumerable<RawMaterial>? ingredients)
    {
        Id = id;
        Name = name;
        PreparationTime = preparationTime;
        Portions = portions;
        ImageUrl = imageUrl;
        Preparation = preparation;
        Calories = calories;
        CommentsSuggestions = commentsSuggestions;
        Ingredients = ingredients;
    }
    #endregion
}