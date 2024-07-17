using MW.SAXSAY.Shared.Abstractions;
using MW.SAXSAY.Shared.Contracts;

namespace MW.SAXSAY.RawMaterial.Domain.Entities;

public sealed class RawMaterial : Entity
{
    #region Properties & Variables
    //
    // public
    //
    public string? Name { get; set; }
    #endregion

    #region Constructor
    private RawMaterial() { }
    #endregion

    /// <summary>
    /// RawMaterial Builder
    /// </summary>
    public class Builder : IBuilder<RawMaterial>
    {
        #region Properties & Variables
        private readonly RawMaterial _rawMaterial = new();
        #endregion

        #region Constructor
        private Builder() { }
        #endregion

        #region Methods
        // pseudo constructor
        public static Builder Empty() => new();

        public RawMaterial Build()
        {
            if (string.IsNullOrWhiteSpace(_rawMaterial.Name))
                throw new InvalidOperationException("Raw material's Name is required");

            return _rawMaterial;
        }

        //
        // building steps
        //
        public Builder WithName(string name)
        {
            _rawMaterial.Name = name;
            return this;
        }
        #endregion
    }
}