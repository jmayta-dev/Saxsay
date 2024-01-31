using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository
{
    ValueTask<Recipe> GetRecipeById(RecipeId id);
    ValueTask<RecipeId> CreateRecipe(Recipe recipe);
}