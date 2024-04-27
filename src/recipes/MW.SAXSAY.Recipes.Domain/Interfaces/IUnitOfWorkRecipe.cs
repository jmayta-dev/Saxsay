namespace MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IUnitOfWorkRecipe : IDisposable
{
    //
    // repositories
    //
    public IRecipeRepository RecipeRepository { get; }
    public IIngredientRepository IngredientRepository { get; }
    //
    // methods
    //
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}