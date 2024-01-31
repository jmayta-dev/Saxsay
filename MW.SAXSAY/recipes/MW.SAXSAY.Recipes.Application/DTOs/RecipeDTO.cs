using recipes.MW.SAXSAY.Recipes.Domain.Entities;
using recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Application.DTOs;

public record RecipeDTO
{
    #region Constructor
    public RecipeDTO()
    {

    }
    #endregion

    public RecipeId Id { get; private set; }
    public PreparationTime PreparationTime { get; set; }
    public int Portions { get; set; }
    public string ImageUrl { get; set; }
    public string Preparation { get; set; }
    public double Calories { get; set; }
    public string CommentsSuggestions { get; set; }
    public IEnumerable<DietaryRestriction>? DietaryRestrictions { get; set; }
    public IEnumerable<RawMaterial>? Ingredients { get; set; }
    public IEnumerable<NutritionalComponent>? NutritionalInformation { get; set; }
}