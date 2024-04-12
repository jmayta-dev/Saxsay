using MW.SAXSAY.Recipes.Application.DTOs;
using MW.SAXSAY.Recipes.Domain.Entities;

namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IRecipeRepository : IDisposable
{
    Task<RecipeId?> RegistraReceta(Recipe recipe, CancellationToken cancellationToken);
}