namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public class Uom
{
    #region Properties
    public string Name { get; set; }
    public string? PluralName { get; set; }
    public string Abbreviation { get; set; }
    public double NumericalValue { get; set; } = 1.0;
    public bool IsActive { get; set; } = true;
    public Uom? BaseUnit { get; set; }
    #endregion

    #region Constructor
    public Uom(
        string name,
        string? pluralName,
        string abbreviation,
        double numericalValue,
        bool isActive,
        Uom? baseUnit
        ) : this(name, pluralName, abbreviation, numericalValue, isActive)
    {
        BaseUnit = baseUnit;
    }

    public Uom(
        string name,
        string? pluralName,
        string abbreviation,
        double numericalValue,
        bool isActive
        ) : this(name, abbreviation, numericalValue, isActive)
    {
        PluralName = pluralName;
    }

    public Uom(
        string name,
        string abbreviation,
        double numericalValue,
        bool isActive
        ) : this(name, abbreviation)
    {
        NumericalValue = numericalValue;
        IsActive = isActive;
    }

    public Uom(
        string name,
        string abbreviation
    )
    {
        Name = name;
        Abbreviation = abbreviation;
    }
    #endregion
}