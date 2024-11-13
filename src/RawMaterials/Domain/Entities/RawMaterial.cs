using MW.SAXSAY.Shared.Abstractions;
using MW.SAXSAY.Shared.Contracts;

namespace MW.SAXSAY.RawMaterials.Domain.Entities;

public sealed class RawMaterial : Entity
{
    #region Properties & Variables
    //
    // public
    //
    public required string Id { get; set; }
    public required string Name { get; init; }
    public required string UNSPSC { get; init; }
    public string UNSPSCDescription { get; init; }
    public required DateTimeOffset? CreatedAt { get; init; }
    public DateTimeOffset? UpdatedAt { get; init; }
    public bool IsEnabled { get; init; }
    #endregion

    #region Constructor
    private RawMaterial() { }
    #endregion


    #region Builder
    /// <summary>
    /// RawMaterial Builder
    /// </summary>
    public class RawMaterialBuilder : IBuilder<RawMaterial>
    {
        #region Properties & Variables
        private string _id;
        private string _name;
        private string _unspsc             = string.Empty;
        private string _unspscDescription  = string.Empty;
        private DateTimeOffset? _createdAt;
        private DateTimeOffset? _updatedAt  = DateTimeOffset.UtcNow;
        private bool _isEnabled             = true;
        #endregion

        #region Constructor
        private RawMaterialBuilder() { }
        #endregion

        #region Methods
        public RawMaterial Build()
        {
            // validations
            if (string.IsNullOrWhiteSpace(_id))
                throw new InvalidOperationException("Raw material's Id is required");

            if (string.IsNullOrWhiteSpace(_name))
                throw new InvalidOperationException("Raw material's Name is required");

            if (_createdAt == null)
                throw new InvalidOperationException("Raw material's Creation Date is required");

            return new RawMaterial {
                Id = _id,
                Name = _name,
                UNSPSC = _unspsc,
                UNSPSCDescription = _unspscDescription,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt,
                IsEnabled = _isEnabled
            };
        }

        public static RawMaterialBuilder Empty() => new();

        //
        // building steps
        //
        public RawMaterialBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public RawMaterialBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public RawMaterialBuilder WithUNSPSC(string? unspsc)
        {
            _unspsc = unspsc ?? string.Empty;
            return this;
        }

        public RawMaterialBuilder WithUNSPSCDescription(string? unspscDescription)
        {
            _unspscDescription = unspscDescription ?? string.Empty;
            return this;
        }

        public RawMaterialBuilder WithCreationDate(DateTimeOffset? createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        public RawMaterialBuilder WithUpdatingDate(DateTimeOffset? updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }

        public RawMaterialBuilder WithEnableState(bool isEnabled)
        {
            _isEnabled = isEnabled;
            return this;
        }
        #endregion
    }
    #endregion
}