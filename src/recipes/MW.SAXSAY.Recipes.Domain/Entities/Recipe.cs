using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Domain.Entities;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Domain.Entities;

public sealed class Recipe : BaseEntity<RecipeId>
{
    #region Properties
    public string? Name { get; set; }
    public PreparationInfo? PreparationInfo { get; set; }
    public int? Portions { get; set; }
    public string? ImageUrl { get; set; }
    public string? CommentsSuggestions { get; set; }
    private readonly List<Ingredient> _ingredients = new();
    public IReadOnlyCollection<Ingredient>? Ingredients => _ingredients.AsReadOnly();
    #endregion

    #region Constructor
    private Recipe() {}
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

    public void ClearIngredients()
    {
        _ingredients.Clear();
    }
    #endregion

    /// <summary>
    /// Recipe Builder
    /// </summary>
    public class RecipeBuilder
    {
        #region Properties & Variables
        //
        // private
        //
        private Recipe _recipe = new();
        #endregion

        #region Constructor
        public RecipeBuilder()
        {
            Reset();
        }
        #endregion

        #region Methods
        private void Reset()
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

        public Recipe Build()
        {
            Recipe recipe = _recipe;
            Reset();
            return recipe;
        }
        #endregion
    }
}
