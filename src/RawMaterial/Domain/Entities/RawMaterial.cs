using MW.SAXSAY.Shared.Abstractions;

namespace MW.SAXSAY.RawMaterial.Domain.Entities;

public sealed class RawMaterial : Entity
{
    #region Properties & Variables
    public string? Name { get; set; }
    #endregion

    #region Constructor
    private RawMaterial()
    {
    }
    #endregion

    public class Builder
    {
        #region Properties & Variables
        private RawMaterial _rawMaterial;
        private string _name;
        #endregion

        #region Constructor
        public Builder()
        {

        }
        #endregion

        #region Methods
        public RawMaterial Build()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void WithName(string name)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}