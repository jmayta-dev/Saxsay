namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public class NutritionalComponent
{
    #region Properties
    public string Component { get; set; }
    public double NumericalValue { get; set; }
    public Uom UnitOfMeasure { get; set; }
    #endregion

    #region Constructor
    public NutritionalComponent(
        string component,
        Uom unitOfMeasure,
        double numericalValue = 0.0
        )
    {
        Component = component;
        NumericalValue = numericalValue;
        UnitOfMeasure = unitOfMeasure;
    }
    #endregion
}