using System.Data;

namespace recipes.MW.SAXSAY.Recipes.Infrastructure.Extension;

public static class DbExtension
{
    #region GetBoolean
    public static bool GetBoolean(this IDataReader reader, string field)
    {
        return reader.GetBoolean(reader.GetOrdinal(field));
    }

    public static bool? GetBooleanOrNull(this IDataReader reader, string field)
    {
        int ordinal = reader.GetOrdinal(field);
        if (reader.IsDBNull(ordinal))
            return null;
        return reader.GetBoolean(ordinal);
    }

    public static bool GetBooleanOrFalse(this IDataReader reader, string field)
    {
        return reader.GetBooleanOrNull(field) ?? false;
    }
    #endregion

    #region GetDecimal
    public static decimal GetDecimal(this IDataReader reader, string field)
    {
        return reader.GetDecimal(reader.GetOrdinal(field));
    }

    public static decimal? GetDecimalOrNull(this IDataReader reader, string field)
    {
        int ordinal = reader.GetOrdinal(field);
        if (reader.IsDBNull(ordinal))
            return null;
        return reader.GetDecimal(ordinal);
    }

    public static decimal? GetDecimalOrZero(this IDataReader reader, string field)
    {
        return reader.GetDecimalOrNull(field) ?? Convert.ToDecimal(0);
    }
    #endregion

    #region GetDouble
    public static double GetDouble(this IDataReader reader, string field)
    {
        return reader.GetDouble(reader.GetOrdinal(field));
    }

    public static double? GetDoubleOrNull(this IDataReader reader, string field)
    {
        int ordinal = reader.GetOrdinal(field);
        if (reader.IsDBNull(ordinal))
            return null;
        return reader.GetDouble(field);
    }

    public static double GetDoubleOrZero(this IDataReader reader, string field)
    {
        return reader.GetDoubleOrNull(field) ?? Convert.ToDouble(0);
    }

    #endregion

    #region GetInt32
    public static int GetInt32(this IDataReader reader, string field)
    {
        return reader.GetInt32(reader.GetOrdinal(field));
    }

    public static int? GetInt32OrNull(this IDataReader reader, string field)
    {
        int ordinal = reader.GetOrdinal(field);
        if (reader.IsDBNull(ordinal))
            return null;
        return reader.GetInt32(ordinal);
    }

    public static int GetInt32OrZero(this IDataReader reader, string field)
    {
        return reader.GetInt32OrNull(field) ?? 0;
    }
    #endregion

    #region GetString
    public static string GetString(this IDataReader reader, string field)
    {
        return reader.GetString(reader.GetOrdinal(field));
    }

    public static string? GetStringOrNull(this IDataReader reader, string field)
    {
        int ordinal = reader.GetOrdinal(field);
        if (reader.IsDBNull(ordinal))
            return null;
        return reader.GetString(ordinal);
    }

    public static string? GetStringOrEmpty(this IDataReader reader, string field)
    {
        return reader.GetStringOrNull(field) ?? string.Empty;
    }
    #endregion
}