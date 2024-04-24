using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Domain.Entities;

public class Ingredient : BaseEntity<IngredientId>
{
    #region Properties
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int BaseUnitId { get; set; }
    #endregion // Properties & Variables

    #region Constructor
    private Ingredient(string description)
    {
        Description = description;
        IsActive = true;
    }
    #endregion // Constructor

    /// <summary>
    /// Ingredient Builder
    /// </summary>
    public class IngredientBuilder
    {
        #region Properties
        //
        // private
        //
        private Ingredient _ingredient = new(string.Empty);
        #endregion

        #region  Constructor
        /// <summary>
        /// Creates a new instance of <see cref="IngredientBuilder"/>
        /// </summary>
        public IngredientBuilder() => Reset();
        #endregion

        #region Methods
        /// <summary>
        /// Builds and return the ingredient builded. Raises an error if required 
        /// properties are not set
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Ingredient Build()
        {
            if (string.IsNullOrWhiteSpace(_ingredient?.Description))
                throw new InvalidOperationException("La descripción es obligatoria.");

            Ingredient ingredient = _ingredient;
            Reset();
            return ingredient;
        }

        /// <summary>
        /// Sets the ingredient id
        /// </summary>
        /// <param name="ingredientId"></param>
        public void WithIngredientId(IngredientId ingredientId) =>
            _ingredient.Id = ingredientId;

        /// <summary>
        /// Sets the ingredient description
        /// </summary>
        /// <param name="description">Ingredient description</param>
        public void WithDescription(string description) =>
            _ingredient.Description = description;

        /// <summary>
        /// Sets the activity status for the ingredient
        /// </summary>
        /// <param name="isActive"></param>
        public void WithStatusActive(bool isActive) => _ingredient.IsActive = isActive;

        /// <summary>
        /// Sets the base unit of measure for the ingredient
        /// </summary>
        /// <param name="baseUnitId">Base unit id</param>
        public void WithBaseUnit(int baseUnitId) => _ingredient.BaseUnitId = baseUnitId;

        /// <summary>
        /// Resets 
        /// </summary>
        public void Reset() => _ingredient = new Ingredient(string.Empty);
        #endregion
    }

}