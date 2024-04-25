using MW.SAXSAY.Ingredients.Domain.Entities;

namespace MW.SAXSAY.Recipes.Application.DTOs;

public record RegisterRecipeDto
{
    public string? Name { get; set; }
    public int? Portions { get; set; }
    public IEnumerable<RegisterIngredientDto>? Ingredients { get; set; }
}
