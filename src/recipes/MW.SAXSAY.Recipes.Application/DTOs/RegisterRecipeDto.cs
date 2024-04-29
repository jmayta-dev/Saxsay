using MW.SAXSAY.RawMaterials.Domain.Entities;

namespace MW.SAXSAY.Recipes.Application.DTOs;

public record RegisterRecipeDto
{
    public string? Name { get; set; }
    public int? Portions { get; set; }
    public IEnumerable<RegisterIngredientDto> Ingredients { get; set; } = new List<RegisterIngredientDto>();
}
