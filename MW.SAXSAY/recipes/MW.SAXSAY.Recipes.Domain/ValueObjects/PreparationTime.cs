using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace recipes.MW.SAXSAY.Recipes.Domain.ValueObjects;

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
    public PreparationTime() => Create(DEFAULT_VALUE);

    private PreparationTime(uint hours, uint minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    #endregion

    #region Methods
    public static PreparationTime? Create() => Create(DEFAULT_VALUE);
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

    public static PreparationTime? Create(uint hours, uint minutes)
    {
        uint totalMinutes = hours * 60 + minutes;
        if (totalMinutes > MAX_TOTAL_MINUTES)
        {
            return null;
        }
        return new PreparationTime(hours, minutes);
    }

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

    private static (uint hours, uint minutes) ParseTimerString(string timerString)
    {
        string[] parts = timerString.Split(":");
        return (uint.Parse(parts[0]), uint.Parse(parts[1]));
    }
    #endregion
}