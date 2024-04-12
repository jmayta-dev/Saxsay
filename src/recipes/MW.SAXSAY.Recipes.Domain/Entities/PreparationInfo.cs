
using MW.SAXSAY.Recipes.Domain.ValueObjects;

namespace MW.SAXSAY.Recipes.Domain.Entities;

public record PreparationInfo
{
    #region Properties
    public PreparationTime? PreparationTime { get; set; }
    public string? PreparationSteps { get; set; }
    #endregion

    #region Constructor
    public PreparationInfo()
    {
        PreparationTime = PreparationTime.Create();
    }

    public PreparationInfo(PreparationTime preparationTime)
    {
        PreparationTime = preparationTime;
    }

    public PreparationInfo(PreparationTime preparationTime, string preparationSteps)
        : this(preparationTime)
    {
        PreparationSteps = preparationSteps;
    }
    #endregion
}