using System.Collections.Immutable;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public sealed class Recipe : IEntity<RecipeId>
{
    #region Properties
    public RecipeId? Id { get; set; }
    public string? Name { get; set; }
    public PreparationInfo? PreparationInfo { get; set; }
    public int? Portions { get; set; }
    public string? ImageUrl { get; set; }
    public string? CommentsSuggestions { get; set; }
    public IReadOnlyCollection<Ingredient>? Ingredients => _ingredients.AsReadOnly();

    private readonly List<Ingredient> _ingredients = new();
    #endregion

    #region Constructor
    #endregion

    #region Methods
    /// <summary>
    /// Add ingredient to recipe ingredient list
    /// </summary>
    /// <param name="ingredient"></param>
    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    public void AddIngredientCollection(IEnumerable<Ingredient> ingredients)
    {
        _ingredients.AddRange(ingredients);
    }

    /// <summary>
    /// Remove ingredient from recipe ingredient list
    /// </summary>
    /// <param name="ingredient"></param>
    public void RemoveIngredient(Ingredient ingredient)
    {
        _ingredients.Remove(ingredient);
    }

    #endregion
    /// <summary>
    /// Recipe Builder
    /// </summary>
    public class Builder
    {
        private Recipe _recipe = new();

        public Builder()
        {
            Reset();
        }

        public void Reset()
        {
            _recipe = new Recipe();
        }

        public void WithRecipeId(RecipeId recipeId)
        {
            _recipe.Id = recipeId;
        }

        public void WithName(string name)
        {
            _recipe.Name = name;
        }

        public void WithPreparationInfo(PreparationInfo preparationInfo)
        {
            _recipe.PreparationInfo = preparationInfo;
        }

        public void WithPortions(int potions)
        {
            _recipe.Portions = potions;
        }

        public void WithImage(string imageUrl)
        {
            _recipe.ImageUrl = imageUrl;
        }

        public void WithCommentsAndSuggestions(string commentsSuggestions)
        {
            _recipe.CommentsSuggestions = commentsSuggestions;
        }

        public Recipe GetRecipe()
        {
            Recipe recipe = _recipe;
            Reset();
            return recipe;
        }
    }
}
