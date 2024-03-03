namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public record NutritionalInfo
{
    #region Properties
    public double Calories { get; set; }
    #endregion

    #region Constructor
    public NutritionalInfo() { }

    public NutritionalInfo(double calories)
    {
        Calories = calories;
    }
    #endregion
}