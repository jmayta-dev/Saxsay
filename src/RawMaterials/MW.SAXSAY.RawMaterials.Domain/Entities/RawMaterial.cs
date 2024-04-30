using MW.SAXSAY.Domain.Common;
using MW.SAXSAY.RawMaterials.Domain.ValueObjects;

namespace MW.SAXSAY.RawMaterials.Domain.Entities;

public class RawMaterial : BaseEntity<RawMaterialId>
{
    #region Properties
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int BaseUnitId { get; set; }
    #endregion // Properties & Variables

    #region Constructor
    private RawMaterial(string description)
    {
        Description = description;
        IsActive = true;
    }
    #endregion // Constructor

    /// <summary>
    /// Ingredient Builder
    /// </summary>
    public class RawMaterialBuilder
    {
        #region Properties
        //
        // private
        //
        private RawMaterial _rawMaterial = new(string.Empty);
        #endregion

        #region  Constructor
        /// <summary>
        /// Creates a new instance of <see cref="RawMaterialBuilder"/>
        /// </summary>
        public RawMaterialBuilder() => Reset();
        #endregion

        #region Methods
        /// <summary>
        /// Builds and return the Raw Material builded. Raises an error if required 
        /// properties are not set
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public RawMaterial Build()
        {
            if (string.IsNullOrWhiteSpace(_rawMaterial?.Description))
                throw new InvalidOperationException("La descripción es obligatoria.");

            RawMaterial rawMaterial = _rawMaterial;
            Reset();
            return rawMaterial;
        }

        /// <summary>
        /// Sets the raw material id
        /// </summary>
        /// <param name="rawMaterialId"></param>
        public void WithIngredientId(RawMaterialId rawMaterialId) =>
            _rawMaterial.Id = rawMaterialId;

        /// <summary>
        /// Sets the raw material description
        /// </summary>
        /// <param name="description">Raw Material description</param>
        public void WithDescription(string description) =>
            _rawMaterial.Description = description;

        /// <summary>
        /// Sets the activity status for the raw material
        /// </summary>
        /// <param name="isActive"></param>
        public void WithStatusActive(bool isActive) => _rawMaterial.IsActive = isActive;

        /// <summary>
        /// Sets the base unit of measure for the raw material
        /// </summary>
        /// <param name="baseUnitId">Base unit id</param>
        public void WithBaseUnit(int baseUnitId) => _rawMaterial.BaseUnitId = baseUnitId;

        /// <summary>
        /// Resets 
        /// </summary>
        public void Reset() => _rawMaterial = new RawMaterial(string.Empty);
        #endregion
    }
}