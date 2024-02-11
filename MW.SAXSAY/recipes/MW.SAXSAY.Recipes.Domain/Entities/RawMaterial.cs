using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public class RawMaterial : IEntity<RawMaterialId>
{
    #region Properties
    public RawMaterialId? Id { get; set; }
    public string Description { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Create a new instance of <see cref="RawMaterial"/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="description"></param>
    public RawMaterial(RawMaterialId? id, string description)
    {
        Id = id;
        Description = description;
    }
    #endregion
}