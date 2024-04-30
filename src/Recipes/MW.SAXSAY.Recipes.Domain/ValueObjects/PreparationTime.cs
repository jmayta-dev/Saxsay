using System.Text.RegularExpressions;

namespace MW.SAXSAY.Recipes.Domain.ValueObjects;

public record PreparationTime
{
    #region Constants & Properties
    //
    // constants
    //
    private const uint DEFAULT_VALUE = 0;
    private const uint MAX_TOTAL_MINUTES = 5999;

    //
    // properties
    //
    public uint Hours { get; init; }
    public uint Minutes { get; init; }
    #endregion

    #region Constructor
    public PreparationTime()
    {
        Hours = 0;
        Minutes = 0;
    }

    private PreparationTime(uint hours, uint minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Create a default PreparationTime timer
    /// </summary>
    /// <returns><see cref="PreparationTime"/></returns>
    public static PreparationTime? Create() => Create(DEFAULT_VALUE);

    /// <summary>
    /// Create a PreparationTime timer from number of minutes
    /// </summary>
    /// <param name="minutes">Number of minutes</param>
    /// <returns><see cref="PreparationTime"/></returns>
    public static PreparationTime? Create(uint minutes)
    {
        uint hours = 0;
        if (minutes > 59)
        {
            hours = minutes / 60;
            minutes -= hours * 60;
        }
        return Create(hours, minutes);
    }

    /// <summary>
    /// Create a PreparationTime timer from number of hours and minutes
    /// </summary>
    /// <param name="hours">Number of hours</param>
    /// <param name="minutes">Number of minutes</param>
    /// <returns><see cref="PreparationTime"/></returns>
    public static PreparationTime? Create(uint hours, uint minutes)
    {
        uint totalMinutes = hours * 60 + minutes;
        if (totalMinutes > MAX_TOTAL_MINUTES)
        {
            return null;
        }
        return new PreparationTime(hours, minutes);
    }

    /// <summary>
    /// Create a PreparationTime timer from string
    /// </summary>
    /// <param name="timerString">String with format "HH:mm"</param>
    /// <returns><see cref="PreparationTime"/></returns>
    public static PreparationTime? Create(string timerString)
    {
        string pattern = @"(\d{2}):([0-5]\d)";
        (uint hours, uint minutes) = (100, 100);
        if (timerString.Length == 5 &&
            Regex.IsMatch(
                timerString,
                pattern,
                RegexOptions.None,
                TimeSpan.FromMilliseconds(100)))
        {
            (hours, minutes) = ParseTimerString(timerString);
        }
        return Create(hours, minutes);
    }

    /// <summary>
    /// Parse from timer in string format to hours and minutes
    /// </summary>
    /// <param name="timerString">String timer format</param>
    /// <returns>tuple with hours and minutes</returns>
    private static (uint hours, uint minutes) ParseTimerString(string timerString)
    {
        string[] parts = timerString.Split(":");
        return (uint.Parse(parts[0]), uint.Parse(parts[1]));
    }

    public override string? ToString()
    {
        return $"{Hours:00}:{Minutes:00}";
    }
    #endregion
}