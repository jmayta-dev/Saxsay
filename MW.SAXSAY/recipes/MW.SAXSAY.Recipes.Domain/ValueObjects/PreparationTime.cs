using System.Net.NetworkInformation;

namespace recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

public record PreparationTime
{
    #region Constants & Properties
    //
    // constants
    //
    private const int DEFAULT_VALUE = 0;
    private const int MAX_TOTAL_MINUTES = 5999;
    //
    // properties
    //
    public int Hours { get; init; }
    public int Minutes { get; init; }
    #endregion

    #region Constructor
    public PreparationTime() => Create(DEFAULT_VALUE);

    private PreparationTime(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    #endregion

    #region Methods
    public static PreparationTime? Create() => Create(DEFAULT_VALUE);
    public static PreparationTime? Create(int minutes)
    {
        int hours = 0;
        if (minutes > 59)
        {
            hours = minutes / 60;
            minutes -= hours * 60;
        }
        return Create(hours, minutes);
    }

    public static PreparationTime? Create(int hours, int minutes)
    {
        int totalMinutes = hours * 60 + minutes;
        if (totalMinutes > MAX_TOTAL_MINUTES)
        {
            return null;
        }
        return new PreparationTime(hours, minutes);
    }
    #endregion
}