using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public class UnitOfMeasure: BaseEntity<UnitOfMeasureId>
{
    #region Properties
    public string Name { get; set; }
    public string? PluralName { get; set; }
    public string Abbreviation { get; set; }
    public double NumericalValue { get; set; } = 1.0;
    public bool IsActive { get; set; } = true;
    public UnitOfMeasure? BaseUnit { get; set; }
    #endregion

    #region Constructor
    public UnitOfMeasure(string name, string abbreviation)
    {
        Name = name;
        Abbreviation = abbreviation;
    }
    #endregion
}