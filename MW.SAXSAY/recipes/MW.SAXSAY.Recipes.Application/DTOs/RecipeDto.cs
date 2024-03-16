using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Application.DTOs;

public record RecipeDto
{
    #region Properties
    public RecipeId Id { get; private set; }
    public string Name { get; set; }
    public PreparationTime PreparationTime { get; set; }
    public int Portions { get; set; }
    public string ImageUrl { get; set; }
    public string Preparation { get; set; }
    public double Calories { get; set; }
    public string CommentsSuggestions { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; }
    #endregion

    #region Constructor
    public RecipeDto() { }
    #endregion
}