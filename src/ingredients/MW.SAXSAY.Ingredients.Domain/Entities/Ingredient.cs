using MW.SAXSAY.Domain;
using MW.SAXSAY.Ingredients.Domain.ValueObjects;

namespace MW.SAXSAY.Ingredients.Domain.Entities;

public class Ingredient : BaseEntity<IngredientId>
{
    #region Properties
    public string Description { get; set; }
    public bool IsActive { get; set; }
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
        public IngredientBuilder()
        {
            Reset();
        }
        #endregion

        #region Methods
        public Ingredient Build()
        {
            if (string.IsNullOrWhiteSpace(_ingredient?.Description))
                throw new InvalidOperationException("La descripción es obligatoria");

            Ingredient ingredient = _ingredient;
            Reset();
            return ingredient;
        }

        public void WithId(IngredientId id)
        {
            _ingredient.Id = id;
        }

        public void WithDescription(string description)
        {
            _ingredient.Description = description;
        }

        public void WithStatusActive(bool isActive)
        {
            _ingredient.IsActive = isActive;
        }

        public void Reset()
        {
            _ingredient = new Ingredient(string.Empty);
        }
        #endregion
    }

}