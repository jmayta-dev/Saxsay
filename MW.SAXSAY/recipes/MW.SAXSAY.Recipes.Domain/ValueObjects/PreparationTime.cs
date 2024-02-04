namespace recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

public partial record PreparationTime
{
    #region Constants & Properties
    //
    // constants
    //
    private const int MAX_TOTAL_MINUTES = 5999;
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
    public static PreparationTime? Set() => Set(0, 0);

    public static PreparationTime? Set(int minutes)
    {
        int hours = 0;
        if (minutes > 59)
        {
            hours = minutes / 60;
            minutes -= hours * 60;
        }
        return Set(hours, minutes);
    }

    public static PreparationTime? Set(int hours, int minutes)
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