using System.Reflection.Metadata.Ecma335;
using recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

namespace recipes.MW.SAXSAY.Recipes.Domain.Entities;

public class DietaryRestriction : IEntity<DietaryRestrictionId>
{
    #region Properties
        public DietaryRestrictionId? Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    #endregion

    #region Constructor
    public DietaryRestriction(DietaryRestrictionId? id, string name, bool status)
    {
        Id = id;
        Name = name;
        Status = status;
    }
    #endregion
}