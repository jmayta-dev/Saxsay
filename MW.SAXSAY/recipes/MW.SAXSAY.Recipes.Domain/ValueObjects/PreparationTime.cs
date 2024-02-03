namespace recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

public partial record PreparationTime
{
    #region Constants & Properties
    //
    // constants
    //
    private const int MaxHours = 99;
    private const int MaxMinutes = 59;
    //
    // properties
    //
    public int Hours { get; init; }
    public int Minutes { get; init; }
    #endregion

    #region Constructor
    private PreparationTime(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Set preparation time
    /// </summary>
    /// <param name="hours">Preparation Hours</param>
    /// <param name="minutes">Preparation Minutes</param>
    /// <returns><see cref="PreparationTime" /></returns>
    public static PreparationTime? Set(int hours, int minutes)
    {
        if (hours > MaxHours && minutes > MaxMinutes)
        {
            return null;
        }
        return new PreparationTime(hours, minutes);
    }
    #endregion
}