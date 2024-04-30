namespace MW.SAXSAY.Recipes.Application.DTOs;

public record RecipeDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? PreparationSteps { get; set; }
    public uint? PreparationTimeHours { get; set; }
    public uint? PreparationTimeMinutes { get; set; }
    public int? Portions { get; set; }
    public string? ImageUrl { get; set; }
    public string? CommentsSuggestions { get; set; }
    public List<IngredientDto>? Ingredients { get; init; }
    // public IReadOnlyCollection<IngredientDto>? Ingredients => _ingredients.AsReadOnly();
}